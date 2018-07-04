using System;
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
        public static List<string> SupportedExtName = new List<string>(new string[] { ".htm", ".html"});

        private Image listItemC;
        public WebPlayerUI(string webUrl)
        {
            InitializeComponent();

            NowUrl = webUrl;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            listItemC = Image.FromFile(Path.Combine(Application.StartupPath, "Images/listBar.png"));

            //plListBar.BackgroundImage = listItemC;
            plListBar.BackgroundImageLayout = ImageLayout.Stretch;

            //显示网页
            web.Navigate(NowUrl);
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

        private void btnBefore_Click(object sender, EventArgs e)
        {
            web.GoForward();
        }

        public string NowUrl { get; set; }
    }
}