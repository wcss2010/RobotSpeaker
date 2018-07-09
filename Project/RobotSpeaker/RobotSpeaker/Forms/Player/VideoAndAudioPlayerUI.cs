using System;
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
        public static List<string> SupportedExtName = new List<string>(new string[] { ".avi",".mp4",".mpg",".3gp",".wav",".mp3",".wmv",".mov" });

        [Browsable(false)]
        public VLCPlayerLib.VlcPlayerControl PlayerCore 
        {
            get { return player; }
        }

        public VideoAndAudioPlayerUI(string videoFile)
        {
            InitializeComponent();

            VideoUrl = videoFile;
            DataService.VideoPlayerUIObj = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            player.InitPlayer();
            if (System.IO.File.Exists(VideoUrl))
            {
                player.SetMediaUrl(VideoUrl);
            }
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            PlayerCore.VlcPlayerCore.Stop();
        }

        public string VideoUrl { get; set; }
    }
}