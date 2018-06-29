using RobotSpeaker.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class MainFormUI : ContentFormBase
    {
        public MainFormUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            TitleLabel.ForeColor = Color.White;
            BackButton.NoFocusImage = Image.FromFile(@"C:\MyCode\RobotSpeaker\Image\goback.png");
            LogoBox.Image = Image.FromFile(@"C:\MyCode\RobotSpeaker\Image\logo.png");
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            MessageBox.Show("Click Back");
        }
    }
}