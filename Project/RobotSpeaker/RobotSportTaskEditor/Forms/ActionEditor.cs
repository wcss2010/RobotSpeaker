using RobotSpeaker.SportDB;
using RobotSportTaskEditor.Tracks;
using RobotSportTaskEditor.Tracks.MotorTrack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeBeam;

namespace RobotSportTaskEditor.Forms
{
    public partial class ActionEditor : Form
    {
        public ActionEditor(bool isNew)
        {
            InitializeComponent();

            //初始化设计控件
            SuperObject.InitActionControl(adcActionControl);

            IsNewRecord = isNew;

            if (IsNewRecord)
            {
                Text = "创建动作";
            }
            else
            {
                Text = "修改动作";
            }

            OnLoad(new EventArgs());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tbCode.Text = Guid.NewGuid().ToString();

            if (Object != null)
            {
                tbCode.Text = Object.Code;
                tbName.Text = Object.Name;
                aceConditionControl.SetConditionString(Object.Condition);

                List<Robot_Steps> stepList = DBInstance.DbHelper.table("Robot_Steps").where("ActionId=?", new object[] { Object.Id }).select("*").getList<Robot_Steps>(new Robot_Steps());
                if (stepList != null)
                {
                    float defaultStart = 40;
                    List<MotorTrackBase> motorList = new List<MotorTrackBase>();
                    foreach (Robot_Steps step in stepList)
                    {
                        Control[] labels = adcActionControl.FindDesignLabel((int)step.MotorIndex);
                        if (labels != null && labels.Length >= 1)
                        {
                            Color backgroundColor = labels[0].BackColor;
                            MotorTrackBase mt = adcActionControl.GetNewMotorTrack(backgroundColor, (int)step.MotorIndex, labels[0].Text.Replace(step.MotorIndex + ",", string.Empty), defaultStart);
                            defaultStart = mt.End + 10;

                            //Sleep
                            mt.BeforeSleep = (int)step.BeforeSleep;
                            mt.AfterSleep = (int)step.AfterSleep;

                            if (step.MotorType == 0)
                            {
                                //旋转电机
                                RevolveTrack rt = (RevolveTrack)mt;
                                rt.Angle = (short)step.Value;
                            }
                            else if (step.MotorType == 1)
                            {
                                //航行电机
                                TravelTrack tt = (TravelTrack)mt;
                                switch (step.Value)
                                {
                                    case 0:
                                        tt.TravelActionType = TravelActionTypes.C_停止;
                                        break;
                                    case 1:
                                        tt.TravelActionType = TravelActionTypes.C_前进;
                                        break;
                                    case 2:
                                        tt.TravelActionType = TravelActionTypes.C_后退;
                                        break;
                                }
                            }
                            else
                            {
                               //呼吸灯
                                LightTrack lt = (LightTrack)mt;
                                switch (step.Value)
                                {
                                    case 0:
                                        lt.LightStateType = LightStateType.C_灭;
                                        break;
                                    case 1:
                                        lt.LightStateType = LightStateType.C_红灯;
                                        break;
                                    case 2:
                                        lt.LightStateType = LightStateType.C_绿灯;
                                        break;
                                    case 3:
                                        lt.LightStateType = LightStateType.C_蓝灯;
                                        break;
                                }
                            }

                            motorList.Add(mt);
                        }
                    }

                    //显示动作
                    adcActionControl.FillTracks(motorList.ToArray());
                }
            }
        }

        public bool IsNewRecord { get; set; }

        private Robot_Actions _object = null;
        public Robot_Actions Object
        {
            get { return _object; }
            set 
            {
                _object = value;
                OnLoad(new EventArgs());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCode.Text))
            {
                MessageBox.Show("请输入代码！");
                return;
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("请输入名称！");
                return;
            }

            if (IsNewRecord)
            {
                _object = new Robot_Actions();
                Object.Id = DBInstance.DbHelper.table("Robot_Actions").select("max(Id)").getValue<long>(0) + 1;
            }

            //更新Code和Name
            Object.Code = tbCode.Text;
            Object.Name = tbName.Text;
            Object.Condition = aceConditionControl.GetConditionString();

            //清理Steps
            DBInstance.DbHelper.table("Robot_Steps").where("ActionId=?", new object[] { Object.Id }).delete();

            //更新Action
            if (IsNewRecord)
            {
                //新境加
                DBInstance.DbHelper.table("Robot_Actions").set("Id", Object.Id).set("Code", Object.Code).set("Name", Object.Name).set("Condition", Object.Condition).insert();
            }
            else
            {
                //更新
                DBInstance.DbHelper.table("Robot_Actions").set("Code", Object.Code).set("Name", Object.Name).set("Condition", Object.Condition).where("Id=?", Object.Id).update();
            }

            foreach (ITimelineTrack track in adcActionControl.DefaultParts.TrackElementList)
            {
                if (track is StartTrack)
                {
                    continue;
                }
                else
                {
                    MotorTrackBase mt = (MotorTrackBase)track;

                    Robot_Steps step = new Robot_Steps();
                    step.Id = DBInstance.DbHelper.table("Robot_Steps").select("max(Id)").getValue<long>(0) + 1;
                    step.ActionId = Object.Id;
                    step.MotorIndex = mt.MotorIndex;
                    step.BeforeSleep = mt.BeforeSleep;
                    step.AfterSleep = mt.AfterSleep;
                    
                    switch (mt.MotorType)
                    {
                        case MotorTypes.C_旋转电机:
                            step.MotorType = 0;
                            step.Value = ((RevolveTrack)mt).Angle;
                            break;
                        case MotorTypes.C_行进电机:
                            step.MotorType = 1;
                            step.Value = ((TravelTrack)mt).TravelActionType == TravelActionTypes.C_停止 ? 0 : ((TravelTrack)mt).TravelActionType == TravelActionTypes.C_前进 ? 1 : 2;
                            break;
                        case MotorTypes.C_其它设备:
                            step.MotorType = 2;
                            step.Value = ((LightTrack)mt).LightStateType == LightStateType.C_灭 ? 0 : (((LightTrack)mt).LightStateType == LightStateType.C_红灯 ? 1 : (((LightTrack)mt).LightStateType == LightStateType.C_绿灯 ? 2 : 3));
                            break;
                    }

                    //添加到数据库
                    DBInstance.DbHelper.table("Robot_Steps").set("Id", step.Id).set("ActionId", step.ActionId).set("MotorIndex", step.MotorIndex).set("MotorType", step.MotorType).set("Value", step.Value).set("BeforeSleep", step.BeforeSleep).set("AfterSleep", step.AfterSleep).insert();
                }
            }

            MessageBox.Show("操作完成！");
            Close();
        }
    }
}