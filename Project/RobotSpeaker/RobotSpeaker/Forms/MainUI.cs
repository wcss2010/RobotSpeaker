using RobotSpeaker.Controls;
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
    public partial class MainUI : PageUIBase
    {
        public MainUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //打开服务
            DataService.Open(this);

            plTabPanel.Top = (Screen.PrimaryScreen.Bounds.Height - plTabPanel.Height) / 2;
            plTabPanel.Left = (Screen.PrimaryScreen.Bounds.Width - plTabPanel.Width) / 2;

            BackButton.NoFocusImage = null;
            BackButton.FocusImage = null;

            ibAbout.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\machine1.png"));
            ibAbout.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\machine2.png"));

            ibGo.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\go1.png"));
            ibGo.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\go2.png"));

            ibFace.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\face1.png"));
            ibFace.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\face2.png"));

            ibVoice.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\voice1.png"));
            ibVoice.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\voice2.png"));

            ibSetting.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\set1.png"));
            ibSetting.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\set2.png"));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            DataService.Close();
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);
        }

        private void ibAbout_Click(object sender, EventArgs e)
        {
            AboutUI ui = new AboutUI();
            ui.Show();
        }

        private void ibGo_Click(object sender, EventArgs e)
        {
            GoUI ui = new GoUI();
            ui.Show();
        }

        private void ibFace_Click(object sender, EventArgs e)
        {
            FaceUI ui = new FaceUI();
            ui.Show();
        }

        private void ibVoice_Click(object sender, EventArgs e)
        {
            VoiceUI ui = new VoiceUI();
            ui.Show();
        }

        private void ibSetting_Click(object sender, EventArgs e)
        {
            PasswordUI pf = new PasswordUI();
            if (pf.ShowDialog() == System.Windows.Forms.DialogResult.OK && pf.TextObj.Text.Equals(SuperObject.Config.ManagerPassword))
            {
                ConfigUI sc = new ConfigUI();
                sc.ShowDialog();
            }
        }
    }
}