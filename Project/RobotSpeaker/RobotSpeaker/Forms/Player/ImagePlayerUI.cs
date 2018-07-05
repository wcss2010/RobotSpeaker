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
    public partial class ImagePlayerUI : PageUIBase
    {
        public static List<string> SupportedExtName = new List<string>(new string[] { ".bmp", ".jpg", ".jpeg", ".png", ".gif" });

        public ImagePlayerUI(string imageFile)
        {
            InitializeComponent();

            ImgUrl = imageFile;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            pbView.Image = Image.FromFile(ImgUrl);
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        public string ImgUrl { get; set; }
    }
}