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
    public partial class PageUIBase : ContentFormBase
    {
        public PageUIBase()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            TitleTextForeColor = Color.White;
            TimeTextForeColor = Color.White;
            try
            {
                BackButton.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\back1.png"));
                BackButton.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\back2.png"));
                LogoBox.Image = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\logo.png"));
                WifiBox.Image = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\wifi.jpg"));
            }
            catch (Exception ex) { }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            //屏掉alt+f4
            if ((e.KeyCode == Keys.F4) && (e.Alt == true))
            {
                e.Handled = true;
            }
        }
    }
}