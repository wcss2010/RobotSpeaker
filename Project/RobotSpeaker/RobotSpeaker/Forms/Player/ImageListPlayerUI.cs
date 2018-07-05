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
    public partial class ImageListPlayerUI : PageUIBase
    {
        DateTime lastSwitchTime = DateTime.Now;

        public ImageListPlayerUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            imageViewerEx.ImageListControl.Height = 0;
            imageViewerEx.ButtonListControl.Height = 0;
            imageViewerEx.SetImagePath(SuperObject.ReadmeDir);

            if (imageViewerEx.GetPageCount() > 0)
            {
                trImageSwitch.Enabled = true;
            }
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        private void trImageSwitch_Tick(object sender, EventArgs e)
        {
            TitleText = "图片展示 还有" + (int)(SuperObject.Config.ImageListPlayerSleepSeconds - (DateTime.Now - lastSwitchTime).TotalSeconds) + "秒切换下一张图...";

            if ((DateTime.Now - lastSwitchTime).TotalSeconds >= SuperObject.Config.ImageListPlayerSleepSeconds)
            {
                lastSwitchTime = DateTime.Now;

                if (imageViewerEx.HasNext())
                {
                    imageViewerEx.Next();
                }
                else
                {
                    imageViewerEx.First();
                }
            }
        }
    }
}