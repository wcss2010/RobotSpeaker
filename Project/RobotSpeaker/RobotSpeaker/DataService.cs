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
        public static void Open()
        {
            
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public static void Close()
        {
           
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

        /// <summary>
        /// 打开服务 
        /// </summary>
        public static void Open(Control parent)
        {
            _joystick_P = new Joystick_P();
            _joystick_P.Click += new EventHandler<JoystickEventArgs>(_joystick_P_Click);
            _joystick_P.Register(parent.Handle, API.JOYSTICKID1);
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
                //int x = 0, y = 0;
                //if ((e.Buttons & JoystickButtons.UP) == JoystickButtons.UP) y--;
                //if ((e.Buttons & JoystickButtons.Down) == JoystickButtons.Down) y++;
                //if ((e.Buttons & JoystickButtons.Left) == JoystickButtons.Left) x--;
                //if ((e.Buttons & JoystickButtons.Right) == JoystickButtons.Right) x++;

                //if (x == -1 && y == -1) this.lbl_Dirt.TextAlign = ContentAlignment.TopLeft;
                //if (x == 0 && y == -1) this.lbl_Dirt.TextAlign = ContentAlignment.TopCenter;
                //if (x == 1 && y == -1) this.lbl_Dirt.TextAlign = ContentAlignment.TopRight;

                //if (x == -1 && y == 0) this.lbl_Dirt.TextAlign = ContentAlignment.MiddleLeft;
                //if (x == 0 && y == 0) this.lbl_Dirt.TextAlign = ContentAlignment.MiddleCenter;
                //if (x == 1 && y == 0) this.lbl_Dirt.TextAlign = ContentAlignment.MiddleRight;

                //if (x == -1 && y == 1) this.lbl_Dirt.TextAlign = ContentAlignment.BottomLeft;
                //if (x == 0 && y == 1) this.lbl_Dirt.TextAlign = ContentAlignment.BottomCenter;
                //if (x == 1 && y == 1) this.lbl_Dirt.TextAlign = ContentAlignment.BottomRight;

                //this.lbl_1.BackColor = ((e.Buttons & JoystickButtons.B1) == JoystickButtons.B1) ? Color.Red : SystemColors.Control;
                //this.lbl_2.BackColor = ((e.Buttons & JoystickButtons.B2) == JoystickButtons.B2) ? Color.Red : SystemColors.Control;
                //this.lbl_3.BackColor = ((e.Buttons & JoystickButtons.B3) == JoystickButtons.B3) ? Color.Red : SystemColors.Control;
                //this.lbl_4.BackColor = ((e.Buttons & JoystickButtons.B4) == JoystickButtons.B4) ? Color.Red : SystemColors.Control;
                //this.lbl_5.BackColor = ((e.Buttons & JoystickButtons.B5) == JoystickButtons.B5) ? Color.Red : SystemColors.Control;
                //this.lbl_6.BackColor = ((e.Buttons & JoystickButtons.B6) == JoystickButtons.B6) ? Color.Red : SystemColors.Control;
                //this.lbl_7.BackColor = ((e.Buttons & JoystickButtons.B7) == JoystickButtons.B7) ? Color.Red : SystemColors.Control;
                //this.lbl_8.BackColor = ((e.Buttons & JoystickButtons.B8) == JoystickButtons.B8) ? Color.Red : SystemColors.Control;
                //this.lbl_9.BackColor = ((e.Buttons & JoystickButtons.B9) == JoystickButtons.B9) ? Color.Red : SystemColors.Control;
                //this.lbl_10.BackColor = ((e.Buttons & JoystickButtons.B10) == JoystickButtons.B10) ? Color.Red : SystemColors.Control;
            }
        }
    }
}