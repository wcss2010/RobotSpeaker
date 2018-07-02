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
    public partial class MainFormUI : PageFormBase
    {
        public MainFormUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.TitleLabel.Text = "";
            this.BackButton.NoFocusImage = null;

            ibAbout.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\machine1.png"));
            ibAbout.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\machine2.png"));
            ibAbout.TextLabel.Text = "自我介绍";
            ibAbout.TextLabel.ForeColor = Color.White;

            ibGo.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\go1.png"));
            ibGo.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\go2.png"));
            ibGo.TextLabel.Text = "遥    控";
            ibGo.TextLabel.ForeColor = Color.White;

            ibFace.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\face1.png"));
            ibFace.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\face2.png"));
            ibFace.TextLabel.Text = "拍照摄像";
            ibFace.TextLabel.ForeColor = Color.White;

            ibVoice.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\voice1.png"));
            ibVoice.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\voice2.png"));
            ibVoice.TextLabel.Text = "语音助手";
            ibVoice.TextLabel.ForeColor = Color.White;

            ibSetting.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\set1.png"));
            ibSetting.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\set2.png"));
            ibSetting.TextLabel.Text = "设    置";
            ibSetting.TextLabel.ForeColor = Color.White;
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);
        }
    }
}