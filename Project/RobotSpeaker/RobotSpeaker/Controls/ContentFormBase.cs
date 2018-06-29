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
        public ImageButton BackButton { get { return this.ibBack; } }

        /// <summary>
        /// 标题栏
        /// </summary>
        public Label TitleLabel { get { return this.lblTitle; } }

        /// <summary>
        /// Logo
        /// </summary>
        public PictureBox LogoBox { get { return this.pbLogo; } }

        /// <summary>
        /// 标题栏面板
        /// </summary>
        public Panel TitlePanel { get { return this.plTopBar; } }

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
    }
}