using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotSportTaskEditor.Forms
{
    public partial class DeviceListForm : Form
    {
        private List<RobotConfigItem> _robotConfigList = new List<RobotConfigItem>();
        /// <summary>
        /// 机器人连接信息列表
        /// </summary>
        public List<RobotConfigItem> RobotConfigList
        {
            get { return _robotConfigList; }
        }

        public RobotConfigItem SelectedRobot { get; set; }

        public DeviceListForm()
        {
            InitializeComponent();
        }

        private void lvConnectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvConnectionList.SelectedItems.Count > 0)
            {
                SelectedRobot = (RobotConfigItem)lvConnectionList.SelectedItems[0].Tag;
            }
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        /// <summary>
        /// 载入配置
        /// </summary>
        public void LoadConfig()
        {
            if (File.Exists(Path.Combine(Application.StartupPath, "RobotConfigList.xml")))
            {
                string txt = File.ReadAllText(Path.Combine(Application.StartupPath, "RobotConfigList.xml"));
                List<RobotConfigItem> list = JsonConvert.DeserializeObject<List<RobotConfigItem>>(txt);
                if (list != null)
                {
                    _robotConfigList = list;
                }
            }

            lvConnectionList.Items.Clear();
            foreach (RobotConfigItem rci in RobotConfigList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = rci.NickName;
                lvi.SubItems.Add(rci.IP);
                lvi.SubItems.Add(rci.Port.ToString());
                lvi.Tag = rci;

                if (MainForm.Client != null)
                {
                    rci.IsUse = MainForm.ClientNickName != null && MainForm.ClientNickName.Equals(rci.NickName);
                }
                else
                {
                    rci.IsUse = false;
                }

                if (rci.IsUse && MainForm.Client.Connections.Count > 0)
                {
                    lvi.SubItems.Add("已连接");
                }
                else
                {
                    lvi.SubItems.Add("未连接");
                }

                lvConnectionList.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        private void SaveConfig()
        {
            File.WriteAllText(Path.Combine(Application.StartupPath, "RobotConfigList.xml"), JsonConvert.SerializeObject(RobotConfigList));
        }

        private void lvConnectionList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedRobot != null)
            {
                btnStartClient.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (lvConnectionList.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem lvi in lvConnectionList.SelectedItems)
                    {
                        RobotConfigList.Remove((RobotConfigItem)lvi.Tag);
                        lvi.Remove();
                    }
                }

                SaveConfig();
                LoadConfig();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DeviceEditorForm def = new DeviceEditorForm();
            def.Text = "新增";
            if (def.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(def.NickName) || string.IsNullOrEmpty(def.IP) || def.Port <= 100)
                {
                    return;
                }
                else
                {
                    RobotConfigItem rci = new RobotConfigItem();
                    rci.NickName = def.NickName;
                    rci.IP = def.IP;
                    rci.Port = def.Port;
                    RobotConfigList.Add(rci);

                    SaveConfig();
                    LoadConfig();
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lvConnectionList.SelectedItems.Count > 0)
            {
                RobotConfigItem rci = (RobotConfigItem)lvConnectionList.SelectedItems[0].Tag;

                DeviceEditorForm def = new DeviceEditorForm();
                def.Text = "修改";
                def.NickName = rci.NickName;
                def.IP = rci.IP;
                def.Port = rci.Port;
                if (def.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rci.NickName = def.NickName;
                    rci.IP = def.IP;
                    rci.Port = def.Port;

                    SaveConfig();
                    LoadConfig();
                }
            }
        }

        private void btnCloseClient_Click(object sender, EventArgs e)
        {
            if (MainForm.Client != null)
            {
                if (MessageBox.Show("真的要断开吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    MainForm.Instance.Text = MainForm.Instance.Tag + "";
                    try
                    {
                        MainForm.Instance.CloseDevice();
                    }
                    catch (Exception ex) { }
                    LoadConfig();
                }
            }
        }

        private void btnStartClient_Click(object sender, EventArgs e)
        {
            if (SelectedRobot != null)
            {
                if (MessageBox.Show("真的要连接吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        MainForm.Instance.OpenDevice(SelectedRobot.NickName, SelectedRobot.IP, SelectedRobot.Port);
                        MainForm.Client.Connected += Client_Connected;
                        MainForm.Client.ConnectionClose += Client_ConnectionClose;
                    }
                    catch (Exception ex) { MessageBox.Show("连接失败！Ex:" + ex.ToString()); }
                    LoadConfig();
                }
            }
        }

        void Client_ConnectionClose(object sender, SocketLibrary.SocketBase.ConCloseMessagesEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                    {
                        LoadConfig();
                    }));
            }
        }

        void Client_Connected(object sender, SocketLibrary.Connection e)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    LoadConfig();
                }));
            }
        }
    }

    /// <summary>
    /// 机器人配置项
    /// </summary>
    public class RobotConfigItem
    {
        public string NickName { get; set; }

        public string IP { get; set; }

        public int Port { get; set; }

        public bool IsUse { get; set; }
    }
}