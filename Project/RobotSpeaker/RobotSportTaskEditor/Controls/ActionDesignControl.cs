using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeBeam.Timing;
using RobotSportTaskEditor.Tracks;
using TimeBeam.Events;
using TimeBeam;
using System.Diagnostics;
using RobotSportTaskEditor.Tracks.MotorTrack;

namespace RobotSportTaskEditor.Controls
{
    public partial class ActionDesignControl : UserControl
    {
        private Dictionary<int, RevolveAngleLimit> _revolveAngleLimitDict = new Dictionary<int, RevolveAngleLimit>();
        /// <summary>
        /// 旋转角度临界值字典
        /// </summary>
        public Dictionary<int, RevolveAngleLimit> RevolveAngleLimitDict
        {
            get { return _revolveAngleLimitDict; }
        }
        
        private TimeBeamClockImpl _clock = new TimeBeamClockImpl();
        private DeviceTrackParts defaultParts = new DeviceTrackParts();
        public DeviceTrackParts DefaultParts
        {
            get { return defaultParts; }
        }

        public ActionDesignControl()
        {
            InitializeComponent();

            tlDesignView.SelectionChanged += TimelineSelectionChanged;
            // Register the clock with the timeline
            tlDesignView.Clock = _clock;

            defaultParts.DisplayText = "动作序列：";
            defaultParts.TrackElementList.Add(new StartTrack());
            tlDesignView.AddTrack(defaultParts);

            plRobotToolBox.Left = (plMiddleContent.Width - plRobotToolBox.Width) / 2;
            plRobotToolBox.Top = (plMiddleContent.Height - plRobotToolBox.Height) / 2;
        }

        /// <summary>
        /// 填充Track列表
        /// </summary>
        /// <param name="tracks"></param>
        public void FillTracks(ITimelineTrack[] tracks)
        {
            if (tracks != null && tracks.Length >= 1)
            {
                //清空列表
                defaultParts.TrackElementList.Clear();

                //添加StartTrack
                defaultParts.TrackElementList.Add(new StartTrack());

                //添加其它项目
                defaultParts.TrackElementList.AddRange(tracks);

                //刷新界面让Track显示
                tlDesignView.UpdateTracks();

                //选择第一个项目
                tlDesignView.SelectTrack(tracks[0]);
            }
        }

        public Control[] FindDesignLabel(int motorIndex)
        {
            string labelName = "lblDevice" + motorIndex;
            return FindDesignControl(labelName);
        }

        public Control[] FindDesignControl(string labelName)
        {   
            return plRobotDesignToolBox.Controls.Find(labelName, true);
        }

        /// <summary>
        /// 清理属性面板
        /// </summary>
        public void ClearPropertyPanel()
        {
            lblSelected.Text = "(无)";
            pgPropertyView.SelectedObject = null;
            pgPropertyView.SelectedObjects = null;
        }

        private void TimelineSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            try
            {
                tlDesignView.Focus();
                if (null != selectionChangedEventArgs.Selected && selectionChangedEventArgs.Selected.Count() > 0)
                {
                    object obj = selectionChangedEventArgs.Selected.ToArray()[0];
                    if (obj is StartTrack)
                    {
                        ClearPropertyPanel();
                    }
                    else
                    {
                        pgPropertyView.SelectedObject = obj;
                        lblSelected.Text = ((MotorTrackBase)selectionChangedEventArgs.Selected.ToArray()[0]).DisplayText;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            plRobotToolBox.Left = (plMiddleContent.Width - plRobotToolBox.Width) / 2;
            plRobotToolBox.Top = (plMiddleContent.Height - plRobotToolBox.Height) / 2;
        }

        private void lblDevice0_Click(object sender, EventArgs e)
        {

        }

        private void tlDesignView_DragEnter(object sender, DragEventArgs e)
        {
            object obj = e.Data.GetData(DataFormats.Text);
            if (obj != null)
            {
                string[] teams = obj.ToString().Split('%');
                if (teams != null && teams.Length >= 2)
                {
                    //读取背景颜色
                    Color backgroundColor = Color.FromArgb(Int32.Parse(teams[0]));
                    string[] subs = teams[1].Split(',');
                    if (subs != null && subs.Length >= 2)
                    {
                        //读取电机序号
                        int motorIndex = Int32.Parse(subs[0]);

                        //电机名称
                        string motorName = subs[1];

                        //查找开始位置
                        float defaultStart = 0;
                        foreach (DeviceTrack t in defaultParts.TrackElementList)
                        {
                            if (t.End > defaultStart)
                            {
                                defaultStart = t.End;
                            }
                        }
                        defaultStart += 10;

                        MotorTrackBase dt = GetNewMotorTrack(backgroundColor, motorIndex, motorName, defaultStart);
                        if (dt != null)
                        {
                            defaultParts.TrackElementList.Add(dt);
                            tlDesignView.UpdateTracks();
                            tlDesignView.SetScrollBarHPos((int)dt.Start);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 生成一个新的MotorTrack
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <param name="motorIndex"></param>
        /// <param name="motorName"></param>
        /// <param name="defaultStart"></param>
        /// <returns></returns>
        public MotorTrackBase GetNewMotorTrack(Color backgroundColor, int motorIndex, string motorName, float defaultStart)
        {
            MotorTrackBase obj = null;

            //判断需要哪个模块显示
            if (motorIndex == 12)
            {
                obj = new LightTrack(motorIndex);
            }
            else if (motorIndex == 10 || motorIndex == 11 || motorIndex == 13)
            {
                //行进电机
                obj = new TravelTrack(motorIndex);
            }
            else
            {
                //旋转电机
                short min = -50;
                short max = 50;

                //尝试查找配置的临界值
                if (RevolveAngleLimitDict.ContainsKey(motorIndex))
                {
                    min = RevolveAngleLimitDict[motorIndex].Min;
                    max = RevolveAngleLimitDict[motorIndex].Max;
                }

                obj = new RevolveTrack(motorIndex, min, max);
            }

            //设置属性
            obj.BackgroundColor = backgroundColor;
            obj.DisplayText = motorName;
            obj.MotorName = motorName;
            obj.Start = defaultStart;
            obj.End = obj.Start + 160;

            return obj;
        }

        private void lblDevice11_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            string destString = string.Empty;
            destString += label.BackColor.ToArgb() + "%";
            destString += label.Text;

            label.DoDragDrop(destString, DragDropEffects.Copy);
        }

        private void lblDevice11_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            plRobotToolBox.Left = (plMiddleContent.Width - plRobotToolBox.Width) / 2;
            plRobotToolBox.Top = (plMiddleContent.Height - plRobotToolBox.Height) / 2;
        }

        private void tlDesignView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (tlDesignView.SelectedTracks.Count() > 0)
                {
                    if (MessageBox.Show("真的要进行吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClearPropertyPanel();

                        foreach (ITimelineTrack tt in tlDesignView.SelectedTracks)
                        {
                            if (tt is StartTrack)
                            {
                                continue;
                            }

                            defaultParts.TrackElementList.Remove(tt);
                        }

                        tlDesignView.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.S)
            {
                if (tlDesignView.SelectedTracks.Count() > 0)
                {
                    ITimelineTrack first = tlDesignView.SelectedTracks.First();
                    int indexx = defaultParts.TrackElementList.IndexOf(first);
                    if (indexx >= 0 && defaultParts.TrackElementList.Count - 1 > indexx)
                    {
                        tlDesignView.SelectTrack(defaultParts.TrackElementList[indexx + 1]);
                    }
                }
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.W)
            {
                if (tlDesignView.SelectedTracks.Count() > 0)
                {
                    ITimelineTrack first = tlDesignView.SelectedTracks.First();
                    int indexx = defaultParts.TrackElementList.IndexOf(first);
                    if (indexx >= 1)
                    {
                        tlDesignView.SelectTrack(defaultParts.TrackElementList[indexx - 1]);
                    }
                }
            }
        }

        private void ActionDesignControl_SizeChanged(object sender, EventArgs e)
        {
            scTopAndDown.SplitterDistance = 120;
            scLeftAndRight.SplitterDistance = 270;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlDesignView_KeyDown(tlDesignView, new KeyEventArgs(Keys.Delete));
        }
    }

    /// <summary>
    /// 旋转电机临界值
    /// </summary>
    public class RevolveAngleLimit
    {
        public RevolveAngleLimit(short min, short max)
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// 最小值
        /// </summary>
        public short Min { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public short Max { get; set; }
    }
}