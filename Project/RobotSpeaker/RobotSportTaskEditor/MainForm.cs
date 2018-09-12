using Noear.Weed;
using SpeakerLibrary.SportDB;
using RobotSportTaskEditor.Forms;
using RobotSportTaskEditor.Tracks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TimeBeam;
using TimeBeam.Events;
using TimeBeam.Timing;
using SpeakerLibrary.Message;
using Newtonsoft.Json;

namespace RobotSportTaskEditor
{
    public partial class MainForm : Form
    {
        private static SocketLibrary.Client _client = null;
        /// <summary>
        /// 客户端
        /// </summary>
        public static SocketLibrary.Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        /// <summary>
        /// 客户端别名
        /// </summary>
        public static string ClientNickName { get; set; }

        public static MainForm Instance { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Instance = this;
            DBInstance.Init(Path.Combine(Application.StartupPath, "static.db"));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadActions();
            LoadQuestions();
        }

        public void LoadQuestions()
        {
            QuestionList = DBInstance.DbHelper.table("Robot_Questions").select("*").getList<Robot_Questions>(new Robot_Questions());
            if (QuestionList != null)
            {
                dgQuestions.Rows.Clear();
                foreach (Robot_Questions q in QuestionList)
                {
                   object[] cells = new object[2];
                   cells[0] = q.Ask;
                   cells[1] = q.Answer;
                   
                   int rowIndex = dgQuestions.Rows.Add(cells);
                   dgQuestions.Rows[rowIndex].Tag = q;
                }
            }
        }

        public void LoadActions()
        {
            ActionList = DBInstance.DbHelper.table("Robot_Actions").select("*").getList<Robot_Actions>(new Robot_Actions());
            if (ActionList != null)
            {
                dgActions.Rows.Clear();
                foreach (Robot_Actions a in ActionList)
                {
                    object[] cells = new object[3];
                    cells[0] = a.Code;
                    cells[1] = a.Name;
                    cells[2] = a.Condition;

                    int rowIndex = dgActions.Rows.Add(cells);
                    dgActions.Rows[rowIndex].Tag = a;
                }
            }
        }

        private void btnNewAction_Click(object sender, EventArgs e)
        {
            new ActionEditor(true).ShowDialog();

            LoadActions();
            LoadQuestions();
        }

        private void btnNewQuestion_Click(object sender, EventArgs e)
        {
            new QuestionEditor(true).ShowDialog();

            LoadActions();
            LoadQuestions();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("真的要退出吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;

                if (Client != null)
                {
                    try
                    {
                        Client.StopClient();
                    }
                    catch (Exception ex) { }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnModifyQuestion_Click(object sender, EventArgs e)
        {
            if (dgQuestions.SelectedRows.Count > 0 && dgQuestions.SelectedRows[0].Tag != null)
            {
                QuestionEditor qe = new QuestionEditor(false);
                qe.Object = (Robot_Questions)dgQuestions.SelectedRows[0].Tag;
                qe.ShowDialog();
            }

            LoadActions();
            LoadQuestions();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dgQuestions.SelectedRows.Count > 0 && dgQuestions.SelectedRows[0].Tag != null)
            {
                Robot_Questions obj = (Robot_Questions)dgQuestions.SelectedRows[0].Tag;
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBInstance.DbHelper.table("Robot_Questions").where("Id = ?", new object[] { obj.Id }).delete();
                }
            }

            LoadActions();
            LoadQuestions();
        }

        private void btnModifyAction_Click(object sender, EventArgs e)
        {
            if (dgActions.SelectedRows.Count > 0 && dgActions.SelectedRows[0].Tag != null)
            {
                ActionEditor ae = new ActionEditor(false);
                ae.Object = (Robot_Actions)dgActions.SelectedRows[0].Tag;
                ae.ShowDialog();
            }

            LoadActions();
            LoadQuestions();
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            if (dgActions.SelectedRows.Count > 0 && dgActions.SelectedRows[0].Tag != null)
            {
                Robot_Actions obj = (Robot_Actions)dgActions.SelectedRows[0].Tag;
                if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DBInstance.DbHelper.table("Robot_Actions").where("Id = ?", new object[] { obj.Id }).delete();
                    DBInstance.DbHelper.table("Robot_Steps").where("ActionId = ?", new object[] { obj.Id }).delete();
                }
            }

            LoadActions();
            LoadQuestions();
        }

        public List<Robot_Actions> ActionList { get; set; }

        public List<Robot_Questions> QuestionList { get; set; }

        private void btnDeviceList_Click(object sender, EventArgs e)
        {
            DeviceListForm df = new DeviceListForm();
            df.ShowDialog();
        }

        private void btnRunAction_Click(object sender, EventArgs e)
        {
            if (dgActions.SelectedRows.Count > 0 && dgActions.SelectedRows[0].Tag != null && Client != null)
            {
                if (MessageBox.Show("真的要执行吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        //构造消息
                        SpeakerLibrary.Message.DebugMessage dm = new SpeakerLibrary.Message.DebugMessage();
                        dm.Command = CommandConst.ActionRun;
                        dm.MsgId = Guid.NewGuid().ToString();
                        SpeakerLibrary.Message.ActionObject actionObject = new SpeakerLibrary.Message.ActionObject();
                        actionObject.Action = (Robot_Actions)dgActions.SelectedRows[0].Tag;
                        actionObject.StepList = DBInstance.DbHelper.table("Robot_Steps").where("ActionId=?", new object[] { actionObject.Action.Id }).select("*").getList<Robot_Steps>(new Robot_Steps()).ToArray();
                        dm.Content = actionObject;

                        //发送消息
                        SocketLibrary.Connection connection;
                        Client.Connections.TryGetValue(Client.ClientName, out connection);
                        if (connection != null)
                        {
                            SocketLibrary.Message message = new SocketLibrary.Message(SocketLibrary.Message.CommandType.SendMessage, SpeakerLibrary.Message.DebugMessage.ToJson(dm));
                            connection.messageQueue.Enqueue(message);
                        }

                        MessageBox.Show("发送完成");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发送失败！");
                    }
                }
            }
        }

        public void OpenDevice(string nickName, string ip, int port)
        {
            CloseDevice();

            Client = new SocketLibrary.Client(ip, port);//此处输入自己的计算机IP地址，端口不能改变
            ClientNickName = nickName;
            Client.MessageReceived += Client_MessageReceived;
            Client.MessageSent += Client_MessageSent;
            Client.Connected += Client_Connected;
            Client.ConnectionClose += Client_ConnectionClose;
            Client.StartClient();
        }

        void Client_ConnectionClose(object sender, SocketLibrary.SocketBase.ConCloseMessagesEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                    {
                        this.Text = this.Tag + "";
                    }));                
            }
        }

        void Client_Connected(object sender, SocketLibrary.Connection e)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    this.Text = this.Tag + "(已连接到" + e.NickName + ")";
                }));
            }            
        }

        void Client_MessageSent(object sender, SocketLibrary.SocketBase.MessageEventArgs e)
        {
            System.Console.WriteLine("Send:" + e.Message.MessageBody);
        }

        void Client_MessageReceived(object sender, SocketLibrary.SocketBase.MessageEventArgs e)
        {
            System.Console.WriteLine("Recv:" + e.Message.MessageBody);
            DebugMessage dm = JsonConvert.DeserializeObject<DebugMessage>(e.Message.MessageBody);
            switch (dm.Command)
            {
                case CommandConst.ActionRunFinish:
                    lblStatus.Text = "动作执行完成！时间：" + DateTime.Now;
                    break;
            }
        }

        public void CloseDevice()
        {
            if (Client != null)
            {
                try
                {
                    Client.StopClient();
                }
                catch (Exception ex) { }

                Client = null;
            }
        }

        private void btnCloneAction_Click(object sender, EventArgs e)
        {
            if (dgActions.SelectedRows.Count > 0 && dgActions.SelectedRows[0].Tag != null)
            {
                if (MessageBox.Show("真的要克隆吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Robot_Actions actionObj = (Robot_Actions)dgActions.SelectedRows[0].Tag;
                    Robot_Steps[] stepList = DBInstance.DbHelper.table("Robot_Steps").where("ActionId=?", new object[] { actionObj.Id }).select("*").getList<Robot_Steps>(new Robot_Steps()).ToArray();

                    if (stepList != null)
                    {
                        //添加Action
                        actionObj.Id = DBInstance.DbHelper.table("Robot_Actions").select("max(Id)").getValue<long>(0) + 1;
                        DBInstance.DbHelper.table("Robot_Actions").set("Id", actionObj.Id).set("Code", actionObj.Code).set("Name", actionObj.Name).set("Condition", actionObj.Condition).insert();

                        //添加StepList
                        foreach (Robot_Steps step in stepList)
                        {
                            step.Id = DBInstance.DbHelper.table("Robot_Steps").select("max(Id)").getValue<long>(0) + 1;
                            step.ActionId = actionObj.Id;
                            DBInstance.DbHelper.table("Robot_Steps").set("Id", step.Id).set("ActionId", step.ActionId).set("MotorIndex", step.MotorIndex).set("MotorType", step.MotorType).set("Value", step.Value).set("BeforeSleep", step.BeforeSleep).set("AfterSleep", step.AfterSleep).insert();
                        }
                    }
                }
            }

            LoadActions();
            LoadQuestions();
        }

        private void btnUploadData_Click(object sender, EventArgs e)
        {
            if (Client != null && Client.Connections.Count >= 1)
            {
                if (MessageBox.Show("真的要同步吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DebugMessage dm = new DebugMessage();
                    dm.Command = CommandConst.UploadDataBase;
                    dm.MsgId = Guid.NewGuid().ToString();
                    dm.Content = Convert.ToBase64String(File.ReadAllBytes(Path.Combine(Application.StartupPath, "static.db")));

                    SocketLibrary.Connection conn = null;
                    Client.Connections.TryGetValue(Client.ClientName, out conn);
                    if (conn != null)
                    {
                        SocketLibrary.Message msg = new SocketLibrary.Message(SocketLibrary.Message.CommandType.SendMessage, DebugMessage.ToJson(dm));
                        conn.messageQueue.Enqueue(msg);
                    }

                    MessageBox.Show("同步完成!");
                }
            }
        }
    }
}