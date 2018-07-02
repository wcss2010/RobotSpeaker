﻿using RobotSpeaker.Controls;
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

            ibAbout.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\machine1.png"));
            ibAbout.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\machine2.png"));

            ibGo.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\go1.png"));
            ibGo.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\go2.png"));

            ibFace.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\face1.png"));
            ibFace.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\face2.png"));

            ibVoice.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\voice1.png"));
            ibVoice.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\voice2.png"));

            ibSetting.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\set1.png"));
            ibSetting.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\set2.png"));
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);
        }
    }
}