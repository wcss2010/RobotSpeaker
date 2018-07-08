using JoyKeys.DirectInputJoy;
using RobotSpeaker.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
        /// 当前的ConfigUI对象
        /// </summary>
        public static ConfigUI ConfigUIObj { get; set; }

        private static JoystickService _joystickServiceObj = new JoystickService();

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            
        }

        /// <summary>
        /// 打开服务 
        /// </summary>
        public static void Open(Control main)
        {
            //打开手柄服务
            _joystickServiceObj.JoystickPressEvent += JoystickService_JoystickPressEvent;
            _joystickServiceObj.Open(main);


        }

        private static void JoystickService_JoystickPressEvent(object sender, JoystickPressEventArgs args)
        {
            if (ConfigUIObj != null) 
            {
                ConfigUIObj.JoystickStateInfo.ProcessorJoystickButtons(args);
            }
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public static void Close()
        {
            //关闭手柄服务
            _joystickServiceObj.Close();
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

        private BackgroundWorker _worker = new BackgroundWorker();

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

        public JoystickService()
        {
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += _worker_DoWork;
        }

        /// <summary>
        /// 主动模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_worker.CancellationPending)
            {
                if (JoystickRunningMode == JoystickRunningModeType.AutoScan)
                {
                    //投递方向按键
                    OnJoystickPressEvent(_joystick_V.X,_joystick_V.Y,_joystick_V.Z, JoystickButtonType.None);

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

            if (_worker.IsBusy)
            {
                return;
            }

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
}