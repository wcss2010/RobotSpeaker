﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms.Player
{
    public partial class WebPlayerUI : PageUIBase
    {
        private Image listItemC;
        public WebPlayerUI(string webUrl)
        {
            InitializeComponent();

            web.Navigate(webUrl);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            listItemC = Image.FromFile(Path.Combine(Application.StartupPath, "Images/listBar.png"));

            plListBar.BackgroundImage = listItemC;
            plListBar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            web.GoBack();
        }
    }
}