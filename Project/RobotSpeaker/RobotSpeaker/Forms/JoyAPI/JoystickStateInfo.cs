using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms.JoyAPI
{
    public partial class JoystickStateInfo : UserControl
    {
        public JoystickStateInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 投递手柄事件
        /// </summary>
        /// <param name="args"></param>
        public void ProcessorJoystickButtons(JoystickPressEventArgs args)
        {
            if (args != null)
            {
                lbl_X.Text = "X:" + args.X;
                lbl_Y.Text = "Y:" + args.Y;
                lbl_Z.Text = "Z:" + args.Z;

                if (args.ButtonType == JoystickButtonType.TopLeft) this.lbl_Dirt.TextAlign = ContentAlignment.TopLeft;
                if (args.ButtonType == JoystickButtonType.TopCenter) this.lbl_Dirt.TextAlign = ContentAlignment.TopCenter;
                if (args.ButtonType == JoystickButtonType.TopRight) this.lbl_Dirt.TextAlign = ContentAlignment.TopRight;

                if (args.ButtonType == JoystickButtonType.MiddleLeft) this.lbl_Dirt.TextAlign = ContentAlignment.MiddleLeft;
                if (args.ButtonType == JoystickButtonType.MiddleCenter) this.lbl_Dirt.TextAlign = ContentAlignment.MiddleCenter;
                if (args.ButtonType == JoystickButtonType.MiddleRight) this.lbl_Dirt.TextAlign = ContentAlignment.MiddleRight;

                if (args.ButtonType == JoystickButtonType.BottomLeft) this.lbl_Dirt.TextAlign = ContentAlignment.BottomLeft;
                if (args.ButtonType == JoystickButtonType.BottomCenter) this.lbl_Dirt.TextAlign = ContentAlignment.BottomCenter;
                if (args.ButtonType == JoystickButtonType.BottomRight) this.lbl_Dirt.TextAlign = ContentAlignment.BottomRight;

                this.lbl_1.BackColor = (args.ButtonType == JoystickButtonType.B1) ? Color.Red : SystemColors.Control;
                this.lbl_2.BackColor = (args.ButtonType == JoystickButtonType.B2) ? Color.Red : SystemColors.Control;
                this.lbl_3.BackColor = (args.ButtonType == JoystickButtonType.B3) ? Color.Red : SystemColors.Control;
                this.lbl_4.BackColor = (args.ButtonType == JoystickButtonType.B4) ? Color.Red : SystemColors.Control;
                this.lbl_5.BackColor = (args.ButtonType == JoystickButtonType.B5) ? Color.Red : SystemColors.Control;
                this.lbl_6.BackColor = (args.ButtonType == JoystickButtonType.B6) ? Color.Red : SystemColors.Control;
                this.lbl_7.BackColor = (args.ButtonType == JoystickButtonType.B7) ? Color.Red : SystemColors.Control;
                this.lbl_8.BackColor = (args.ButtonType == JoystickButtonType.B8) ? Color.Red : SystemColors.Control;
                this.lbl_9.BackColor = (args.ButtonType == JoystickButtonType.B9) ? Color.Red : SystemColors.Control;
                this.lbl_10.BackColor = (args.ButtonType == JoystickButtonType.B10) ? Color.Red : SystemColors.Control;
            }
        }
    }
}