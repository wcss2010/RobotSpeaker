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
    public partial class PageFormBase : ContentFormBase
    {
        public PageFormBase()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            TitleTextColor = Color.White;
            try
            {
                BackButton.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\goback.png"));
                LogoBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\logo.png"));
            }
            catch (Exception ex) { }
        }
    }
}