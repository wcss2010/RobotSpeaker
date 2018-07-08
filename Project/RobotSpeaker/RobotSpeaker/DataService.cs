using JoyKeys.DirectInputJoy;
using RobotSpeaker.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
            
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public static void Close()
        {
           
        }
    }

    public delegate void JoystickPressEventDelegate(object sender, JoystickPressEventArgs args);

    public class JoystickPressEventArgs : EventArgs
    {
        /// <summary>
        /// 按键类型
        /// </summary>
        public JoystickButtonType ButtonType { get; set; }

        public JoystickPressEventArgs(JoystickButtonType bt)
        {
            ButtonType = bt;
        }
    }

    /// <summary>
    /// 游戏手柄服务
    /// </summary>
    public class JoystickService
    {
        private static bool _isPassivity = true;
        /// <summary>
        /// 被动式扫描
        /// </summary>
        public static bool IsPassivity
        {
            get { return _isPassivity; }
            set { _isPassivity = value; }
        }

        /// <summary>
        /// 主动式手柄对象
        /// </summary>
        private static Joystick_V _joystick_V = null;
        /// <summary>
        /// 被动式手柄对象
        /// </summary>
        private static Joystick_P _joystick_P = null;

        public static JoystickPressEventDelegate JoystickPressEvent;

        private static void OnJoystickPressEvent(JoystickButtonType bt)
        {
            if (JoystickPressEvent != null)
            {
                JoystickPressEvent(null, new JoystickPressEventArgs(bt));
            }
        }

        /// <summary>
        /// 打开服务 
        /// </summary>
        public static void Open(Control main)
        {
            _joystick_P = new Joystick_P();
            _joystick_P.Click += new EventHandler<JoystickEventArgs>(_joystick_P_Click);
            _joystick_P.Register(main.Handle, API.JOYSTICKID1);
            _joystick_V = Joystick_V.ReturnJoystick(API.JOYSTICKID1);
            _joystick_V.Capture();
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public static void Close()
        {
            _joystick_P.Click -= new EventHandler<JoystickEventArgs>(_joystick_P_Click);
            _joystick_P.UnRegister(API.JOYSTICKID1);
            _joystick_V.ReleaseCapture();
            _joystick_V.Dispose();
        }

        private static void _joystick_P_Click(object sender, JoystickEventArgs e)
        {
            if (IsPassivity)
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
        TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, MiddleRight, BottomLeft, BottomCenter, BottomRight,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10
    }
}