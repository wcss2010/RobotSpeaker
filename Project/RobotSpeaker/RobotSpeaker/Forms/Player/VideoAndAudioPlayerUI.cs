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
    public partial class VideoAndAudioPlayerUI : PageUIBase
    {
        public VideoAndAudioPlayerUI(string videoFile)
        {
            InitializeComponent();

            if (System.IO.File.Exists(videoFile))
            {
                player.URL = videoFile;
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