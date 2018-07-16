using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class GoUI : PageUIBase
    {
        public GoUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            plTabPanel.Top = (Screen.PrimaryScreen.Bounds.Height - plTabPanel.Height) / 2;
            plTabPanel.Left = (Screen.PrimaryScreen.Bounds.Width - plTabPanel.Width) / 2;

            ibNormal.NoFocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\goNormal1.png"));
            ibNormal.FocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\goNormal2.png"));
            ibNormal.EnabledMouseDownAndMouseUp = false;

            ibUseDevice.NoFocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\goJoy1.png"));
            ibUseDevice.FocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\goJoy2.png"));
            ibUseDevice.EnabledMouseDownAndMouseUp = false;

            ibFree.NoFocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\goFree1.png"));
            ibFree.FocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\goFree2.png"));
            ibFree.EnabledMouseDownAndMouseUp = false;

            //切换按钮状态
            SwitchButtonState(SuperObject.Config.CurrentGoType);
        }

        /// <summary>
        /// 切换按钮状态
        /// </summary>
        /// <param name="goTypes"></param>
        private void SwitchButtonState(GoType goTypes)
        {
            switch (goTypes)
            {
                case GoType.Normal:
                    ibNormal.IsPressed = true;
                    ibUseDevice.IsPressed = false;
                    ibFree.IsPressed = false;
                    break;
                case GoType.Joy:
                    ibNormal.IsPressed = false;
                    ibUseDevice.IsPressed = true;
                    ibFree.IsPressed = false;
                    break;
                case GoType.Free:
                    ibNormal.IsPressed = false;
                    ibUseDevice.IsPressed = false;
                    ibFree.IsPressed = true;
                    break;

                default:
                    ibNormal.IsPressed = true;
                    ibUseDevice.IsPressed = false;
                    ibFree.IsPressed = false;
                    break;
            }
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        private void ibNormal_Click(object sender, EventArgs e)
        {
            SuperObject.Config.CurrentGoType = GoType.Normal;
            SwitchButtonState(SuperObject.Config.CurrentGoType);
            SuperObject.SaveConfig();
        }

        private void ibUseDevice_Click(object sender, EventArgs e)
        {
            SuperObject.Config.CurrentGoType = GoType.Joy;
            SwitchButtonState(SuperObject.Config.CurrentGoType);
            SuperObject.SaveConfig();
        }

        private void ibFree_Click(object sender, EventArgs e)
        {
            SuperObject.Config.CurrentGoType = GoType.Free;
            SwitchButtonState(SuperObject.Config.CurrentGoType);
            SuperObject.SaveConfig();

            if (File.Exists(SuperObject.Config.GoAppPath))
            {
                try
                {
                    System.Diagnostics.Process.Start(SuperObject.Config.GoAppPath);
                }
                catch (Exception ex) { }
            }
        }
    }
}