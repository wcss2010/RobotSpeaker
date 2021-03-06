﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms.Player
{
    public partial class TextPlayerUI : PageUIBase
    {
        public static List<string> SupportedExtName = new List<string>(new string[] { ".txt" });

        public TextPlayerUI(string txtFile)
        {
            InitializeComponent();

            if (System.IO.File.Exists(txtFile))
            {
                txtContent.Text = System.IO.File.ReadAllText(txtFile);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }
    }
}