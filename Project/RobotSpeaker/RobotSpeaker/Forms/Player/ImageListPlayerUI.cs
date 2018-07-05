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
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        private void trImageSwitch_Tick(object sender, EventArgs e)
        {

        }
    }
}