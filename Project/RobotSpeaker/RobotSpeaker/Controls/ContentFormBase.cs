using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Controls
{
    /// <summary>
    /// 内容窗体(带返回按钮和Logo)
    /// </summary>
    public partial class ContentFormBase : FullScreenFormBase
    {
        /// <summary>
        /// 返回按钮
        /// </summary>
        [Browsable(false)]
        public ImageButton BackButton { get { return this.ibBack; } }

        /// <summary>
        /// 标题栏
        /// </summary>
        [Browsable(false)]
        public Label TitleLabel { get { return this.lblTitle; } }

        /// <summary>
        /// Logo
        /// </summary>
        [Browsable(false)]
        public PictureBox LogoBox { get { return this.pbLogo; } }

        /// <summary>
        /// Wifi图标
        /// </summary>
        [Browsable(false)]
        public PictureBox WifiBox { get { return this.pbWifi; } }

        /// <summary>
        /// 标题栏面板
        /// </summary>
        [Browsable(false)]
        public Panel TitlePanel { get { return this.plTopBar; } }

        public string TitleText
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        public Font TitleTextFont
        {
            get { return TitleLabel.Font; }
            set { TitleLabel.Font = value; }
        }

        public Color TitleTextColor
        {
            get { return TitleLabel.ForeColor; }
            set { TitleLabel.ForeColor = value; }
        }

        public Font TimeTextFont 
        {
            get { return lblTime.Font; }
            set { lblTime.Font = value; }
        }

        public Color TimeTextColor
        {
            get { return lblTime.ForeColor; }
            set { lblTime.ForeColor = value; }
        }

        public ContentFormBase()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void ibBack_Click(object sender, EventArgs e)
        {
            this.OnClickBackButton(e);
        }

        /// <summary>
        /// 返回按钮点击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClickBackButton(EventArgs e) { }

        private void trTimeUpdate_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ddd");
        }
    }
}