using AIUISerials;
using JoyKeys.DirectInputJoy;
using RobotSpeaker.Forms;
using RobotSpeaker.Forms.Player;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using RobotSpeaker.SportDB;

namespace RobotSpeaker
{
    /// <summary>
    /// 数据服务
    /// </summary>
    public class DataService
    {
        /// <summary>
        /// 图片缓存
        /// </summary>
        public static Dictionary<string, Image> imageDict = new Dictionary<string, Image>();

        /// <summary>
        /// 载入图片（带缓存）
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Image GetImage(string filePath)
        {
            if (imageDict.ContainsKey(filePath))
            {
                return imageDict[filePath];
            }
            else
            {
                try
                {
                    Image img = Image.FromFile(filePath);
                    imageDict[filePath] = img;

                    return imageDict[filePath];
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 聊天界面对象
        /// </summary>
        public static VoiceUI VoiceUIObj { get; set; }

        /// <summary>
        /// 配置界面对象
        /// </summary>
        public static ConfigUI ConfigUIObj { get; set; }

        /// <summary>
        /// 视频播放器界面对象
        /// </summary>
        public static VideoAndAudioPlayerUI VideoPlayerUIObj { get; set; }

        /// <summary>
        /// 设备调试界面对象
        /// </summary>
        public static DeviceDebugUI DeviceDebugUIObj { get; set; }

        /// <summary>
        /// 主窗体
        /// </summary>
        public static MainUI MainUIObj { get; set; }

        /// <summary>
        /// 手柄服务
        /// </summary>
        private static JoystickService _joystickServiceObj = new JoystickService();

        private static AIUIService _aiuiService = new AIUIService();
        /// <summary>
        /// AIUI服务
        /// </summary>
        public static AIUIService AiuiService
        {
            get { return DataService._aiuiService; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            DBInstance.Init(Path.Combine(Application.StartupPath, "static.db"));
        }

        /// <summary>
        /// 打开服务 
        /// </summary>
        public static void Open(MainUI mains)
        {
            MainUIObj = mains;

            //打开手柄服务
            _joystickServiceObj.JoystickPressEvent += JoystickService_JoystickPressEvent;
            _joystickServiceObj.Open(MainUIObj);

            //打开语音服务
            _aiuiService.Open();
        }

        private static void JoystickService_JoystickPressEvent(object sender, JoystickPressEventArgs args)
        {
            if (MainUIObj != null)
            {
                if (MainUIObj.IsHandleCreated)
                {
                    MainUIObj.Invoke(new MethodInvoker(delegate()
                        {
                            if (ConfigUIObj != null)
                            {
                                ConfigUIObj.JoystickStateInfo.ProcessorJoystickButtons(args);
                            }
                        }));
                }
            }
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public static void Close()
        {
            //关闭手柄服务
            _joystickServiceObj.Close();

            //关闭语音服务
            _aiuiService.Close();
        }

        /// <summary>
        /// 重置本地服务
        /// </summary>
        public static void Reset()
        {
            //重置AIUI服务
            AiuiService.Close();
            AiuiService.Open();

            //重置运动服务

        }
    }

    public delegate void JoystickPressEventDelegate(object sender, JoystickPressEventArgs args);

    public class JoystickPressEventArgs : EventArgs
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        /// <summary>
        /// 按键类型
        /// </summary>
        public JoystickButtonType ButtonType { get; set; }

        public JoystickPressEventArgs(int xx, int yy, int zz, JoystickButtonType btt)
        {
            this.X = xx;
            this.Y = yy;
            this.Z = zz;

            ButtonType = btt;
        }
    }

    /// <summary>
    /// 游戏手柄服务
    /// </summary>
    public class JoystickService
    {
        private JoystickRunningModeType _joystickRunningMode = JoystickRunningModeType.ReceiveOnly;
        /// <summary>
        /// 手柄运行方式
        /// </summary>
        public JoystickRunningModeType JoystickRunningMode
        {
            get { return _joystickRunningMode; }
            set { _joystickRunningMode = value; }
        }

        /// <summary>
        /// 主动式手柄对象
        /// </summary>
        private Joystick_V _joystick_V = null;
        /// <summary>
        /// 被动式手柄对象
        /// </summary>
        private Joystick_P _joystick_P = null;

        private BackgroundWorker _worker = null;

        public event JoystickPressEventDelegate JoystickPressEvent;

        private void OnJoystickPressEvent(int xxx, int yyy, int zzz, JoystickButtonType btt)
        {
            if (JoystickPressEvent != null)
            {
                JoystickPressEvent(null, new JoystickPressEventArgs(xxx, yyy, zzz, btt));
            }
        }

        private void OnJoystickPressEvent(JoystickButtonType bttt)
        {
            OnJoystickPressEvent(0, 0, 0, bttt);
        }

        /// <summary>
        /// 主动模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!((BackgroundWorker)sender).CancellationPending)
            {
                if (JoystickRunningMode == JoystickRunningModeType.AutoScan)
                {
                    //投递方向按键
                    OnJoystickPressEvent(_joystick_V.X, _joystick_V.Y, _joystick_V.Z, JoystickButtonType.None);

                    //投递B10-B10按键
                    if (((_joystick_V.CurButtonsState & JoystickButtons.B1) == JoystickButtons.B1))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B1);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B2) == JoystickButtons.B2))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B2);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B3) == JoystickButtons.B3))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B3);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B4) == JoystickButtons.B4))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B4);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B5) == JoystickButtons.B5))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B5);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B6) == JoystickButtons.B6))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B6);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B7) == JoystickButtons.B7))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B7);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B8) == JoystickButtons.B8))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B8);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B9) == JoystickButtons.B9))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B9);
                    }
                    else if (((_joystick_V.CurButtonsState & JoystickButtons.B10) == JoystickButtons.B10))
                    {
                        OnJoystickPressEvent(JoystickButtonType.B10);
                    }
                }

                try
                {
                    Thread.Sleep(100);
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// 打开服务 
        /// </summary>
        public void Open(Control main)
        {
            _joystick_P = new Joystick_P();
            _joystick_P.Click += new EventHandler<JoystickEventArgs>(_joystick_P_Click);
            _joystick_P.Register(main.Handle, API.JOYSTICKID1);
            _joystick_V = Joystick_V.ReturnJoystick(API.JOYSTICKID1);
            _joystick_V.Capture();

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += _worker_DoWork;

            _worker.RunWorkerAsync();
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public void Close()
        {
            _joystick_P.Click -= new EventHandler<JoystickEventArgs>(_joystick_P_Click);
            _joystick_P.UnRegister(API.JOYSTICKID1);
            _joystick_V.ReleaseCapture();
            _joystick_V.Dispose();

            _worker.CancelAsync();
            _worker = null;
        }

        /// <summary>
        /// 被动模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _joystick_P_Click(object sender, JoystickEventArgs e)
        {
            if (JoystickRunningMode == JoystickRunningModeType.ReceiveOnly)
            {
                //检测方向键
                int x = 0, y = 0;
                if ((e.Buttons & JoystickButtons.UP) == JoystickButtons.UP) y--;
                if ((e.Buttons & JoystickButtons.Down) == JoystickButtons.Down) y++;
                if ((e.Buttons & JoystickButtons.Left) == JoystickButtons.Left) x--;
                if ((e.Buttons & JoystickButtons.Right) == JoystickButtons.Right) x++;

                if (x == -1 && y == -1) OnJoystickPressEvent(JoystickButtonType.TopLeft);
                if (x == 0 && y == -1) OnJoystickPressEvent(JoystickButtonType.TopCenter);
                if (x == 1 && y == -1) OnJoystickPressEvent(JoystickButtonType.TopRight);

                if (x == -1 && y == 0) OnJoystickPressEvent(JoystickButtonType.MiddleLeft);
                if (x == 0 && y == 0) OnJoystickPressEvent(JoystickButtonType.MiddleCenter);
                if (x == 1 && y == 0) OnJoystickPressEvent(JoystickButtonType.MiddleRight);

                if (x == -1 && y == 1) OnJoystickPressEvent(JoystickButtonType.BottomLeft);
                if (x == 0 && y == 1) OnJoystickPressEvent(JoystickButtonType.BottomCenter);
                if (x == 1 && y == 1) OnJoystickPressEvent(JoystickButtonType.BottomRight);

                //检查B1-B10的按键
                if ((e.Buttons & JoystickButtons.B1) == JoystickButtons.B1)
                {
                    OnJoystickPressEvent(JoystickButtonType.B1);
                }
                else if ((e.Buttons & JoystickButtons.B2) == JoystickButtons.B2)
                {
                    OnJoystickPressEvent(JoystickButtonType.B2);
                }
                else if ((e.Buttons & JoystickButtons.B3) == JoystickButtons.B3)
                {
                    OnJoystickPressEvent(JoystickButtonType.B3);
                }
                else if ((e.Buttons & JoystickButtons.B4) == JoystickButtons.B4)
                {
                    OnJoystickPressEvent(JoystickButtonType.B4);
                }
                else if ((e.Buttons & JoystickButtons.B5) == JoystickButtons.B5)
                {
                    OnJoystickPressEvent(JoystickButtonType.B5);
                }
                else if ((e.Buttons & JoystickButtons.B6) == JoystickButtons.B6)
                {
                    OnJoystickPressEvent(JoystickButtonType.B6);
                }
                else if ((e.Buttons & JoystickButtons.B7) == JoystickButtons.B7)
                {
                    OnJoystickPressEvent(JoystickButtonType.B7);
                }
                else if ((e.Buttons & JoystickButtons.B8) == JoystickButtons.B8)
                {
                    OnJoystickPressEvent(JoystickButtonType.B8);
                }
                else if ((e.Buttons & JoystickButtons.B9) == JoystickButtons.B9)
                {
                    OnJoystickPressEvent(JoystickButtonType.B9);
                }
                else if ((e.Buttons & JoystickButtons.B10) == JoystickButtons.B10)
                {
                    OnJoystickPressEvent(JoystickButtonType.B10);
                }
            }
        }
    }

    /// <summary>
    /// 手柄按键
    /// </summary>
    public enum JoystickButtonType
    {
        TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, MiddleRight, BottomLeft, BottomCenter, BottomRight, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, None
    }

    /// <summary>
    /// 手柄运行方式(AutoScan(主动扫描模式),ReceiveOnly(被动接收模式))
    /// </summary>
    public enum JoystickRunningModeType
    {
        AutoScan, ReceiveOnly
    }

    /// <summary>
    /// AIUI监听服务
    /// </summary>
    public class AIUIService
    {
        private XFJsonResolver _xfJsonResolver = new XFJsonResolver();
        /// <summary>
        /// 讯飞Json解析器
        /// </summary>
        public XFJsonResolver XfJsonResolver
        {
            get { return _xfJsonResolver; }
        }

        public AIUIService()
        {
            XfJsonResolver.XFCardLocationEvent += XfJsonResolver_XFCardLocationEvent;
            XfJsonResolver.XFCardWakeupEvent += XfJsonResolver_XFCardWakeupEvent;
            XfJsonResolver.XFCardQuestionEvent += XfJsonResolver_XFCardQuestionEvent;
        }

        void XfJsonResolver_XFCardQuestionEvent(object sender, XFQuestionEventArgs args)
        {
            if (DataService.MainUIObj.IsHandleCreated)
            {
                DataService.MainUIObj.Invoke(new MethodInvoker(delegate()
                    {
                        //if (DataService.VoiceUIObj == null)
                        //{
                        //    DataService.VoiceUIObj = new VoiceUI();
                        //    DataService.VoiceUIObj.Show();
                        //}

                        if (DataService.VoiceUIObj != null)
                        {
                            if (args.Ask != null && args.Ask.Trim().Length > 0)
                            {
                                //显示问话
                                DataService.VoiceUIObj.ChatPanel.AddUserMsg(args.Ask.Trim());
                            }
                            if (args.Answer != null && args.Answer.Trim().Length > 0)
                            {
                                //显示答话
                                DataService.VoiceUIObj.ChatPanel.AddMachineMsg(args.Answer.Trim());
                            }
                        }
                    }));
            }
        }

        void XfJsonResolver_XFCardWakeupEvent(object sender, EventArgs args)
        {
            if (DataService.MainUIObj.IsHandleCreated)
            {
                DataService.MainUIObj.Invoke(new MethodInvoker(delegate()
                    {
                        if (DataService.VideoPlayerUIObj != null)
                        {
                            try
                            {
                                DataService.VideoPlayerUIObj.Close();
                            }
                            catch (Exception ex) { }

                            DataService.VideoPlayerUIObj = null;
                        }
                    }));
            }
        }

        void XfJsonResolver_XFCardLocationEvent(object sender, XFSpeakerLocationEventArgs args)
        {
            if (DataService.MainUIObj.IsHandleCreated)
            {
                DataService.MainUIObj.Invoke(new MethodInvoker(delegate()
                {
                    if (DataService.VideoPlayerUIObj != null)
                    {
                        try
                        {
                            DataService.VideoPlayerUIObj.Close();
                        }
                        catch (Exception ex) { }

                        DataService.VideoPlayerUIObj = null;
                    }
                }));
            }
        }

        private AIUIConnection _aiuiConnection = null;
        /// <summary>
        /// AIUI连接
        /// </summary>
        public AIUIConnection AiuiConnection
        {
            get { return _aiuiConnection; }
        }

        public void Open()
        {
            //先关闭之前的
            Close();

            _aiuiConnection = new AIUIConnection(SuperObject.Config.OnlineVoicePort);
            _aiuiConnection.AIUIConnectionReceivedEvent += _aiuiConnection_AIUIConnectionReceivedEvent;

            //检查是否启动了在线模式
            if (SuperObject.Config.EnabledOnlineVoice)
            {
                _aiuiConnection.SerialPort.Connect();
            }
        }

        void _aiuiConnection_AIUIConnectionReceivedEvent(object sender, AIUIConnectionReceivedEventArgs args)
        {
            if (DataService.DeviceDebugUIObj != null)
            {
                DataService.DeviceDebugUIObj.PrintDebugLog(args.Json);
            }

            //解析Json
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
                {
                    XfJsonResolver.Resolve(args.Json);
                }));
        }

        public void Close()
        {
            if (_aiuiConnection != null)
            {
                _aiuiConnection.SerialPort.Disconnect();
            }
        }
    }

    /// <summary>
    /// 唤醒
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardWakeupDelegate(object sender, EventArgs args);

    /// <summary>
    /// 讲话人角度
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardSpeakerLocationDelegate(object sender, XFSpeakerLocationEventArgs args);

    public class XFSpeakerLocationEventArgs : EventArgs
    {
        /// <summary>
        /// 角度
        /// </summary>
        public double Angle { get; set; }
    }

    /// <summary>
    /// 问答
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardQuestionDelegate(object sender, XFQuestionEventArgs args);

    public class XFQuestionEventArgs : EventArgs
    {
        /// <summary>
        /// 问
        /// </summary>
        public string Ask { get; set; }

        /// <summary>
        /// 答
        /// </summary>
        public string Answer { get; set; }
    }

    /// <summary>
    /// 讯飞Json字符解析器
    /// </summary>
    public class XFJsonResolver
    {
        /// <summary>
        /// 唤醒
        /// </summary>
        public event XFCardWakeupDelegate XFCardWakeupEvent;
        /// <summary>
        /// 角度
        /// </summary>
        public event XFCardSpeakerLocationDelegate XFCardLocationEvent;
        /// <summary>
        /// 问答
        /// </summary>
        public event XFCardQuestionDelegate XFCardQuestionEvent;

        protected void OnXFCardWakeupEvent()
        {
            if (XFCardWakeupEvent != null)
            {
                XFCardWakeupEvent(this, new EventArgs());
            }
        }

        protected void OnXFCardLocationEvent(double angle)
        {
            if (XFCardLocationEvent != null)
            {
                XFSpeakerLocationEventArgs obj = new XFSpeakerLocationEventArgs();
                obj.Angle = angle;

                XFCardLocationEvent(this, obj);
            }
        }

        protected void OnXFCardQuestionEvent(string ask, string answer)
        {
            if (XFCardQuestionEvent != null)
            {
                XFQuestionEventArgs obj = new XFQuestionEventArgs();
                obj.Ask = ask;
                obj.Answer = answer;

                XFCardQuestionEvent(this, obj);
            }
        }

        public void Resolve(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            else
            {
                try
                {
                    //解析Json字符串
                    JObject firstObj = (JObject)JsonConvert.DeserializeObject(json);

                    JToken eventStr = firstObj["type"];
                    if (eventStr.ToString().Equals("aiui_event"))
                    {
                        //是aiui_event才解析
                        JToken contentObj = firstObj["content"];
                        if (contentObj != null)
                        {
                            //判断是不是结果集消息
                            if (contentObj["result"] != null)
                            {
                                //结果集消息
                                if (contentObj["result"]["intent"] != null)
                                {
                                    JToken answers = contentObj["result"]["intent"];
                                    string askStr = string.Empty;
                                    string answerStr = string.Empty;

                                    if (answers["text"] != null)
                                    {
                                        //问的话
                                        askStr = answers["text"].ToString();
                                    }

                                    if (answers["answer"] != null && answers["answer"]["text"] != null)
                                    {
                                        //答的话
                                        answerStr = answers["answer"]["text"].ToString();
                                    }

                                    //投递答案
                                    OnXFCardQuestionEvent(askStr, answerStr);
                                }
                            }
                            else
                            {
                                //应该是某个提醒
                                if (contentObj["info"] != null)
                                {
                                    if (contentObj["info"]["wakeup_mode"] != null)
                                    {
                                        //唤醒消息
                                        OnXFCardWakeupEvent();
                                    }
                                    else if (contentObj["info"]["angle"] != null)
                                    {
                                        //角度消息
                                        OnXFCardLocationEvent(double.Parse(contentObj["info"]["angle"].ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("解析错误！Ex:" + ex.ToString());
                }
            }
        }
    }
}