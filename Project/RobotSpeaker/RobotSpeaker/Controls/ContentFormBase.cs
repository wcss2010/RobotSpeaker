using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Controls
{
    /// <summary>
    /// 内容窗体(带返回按钮和Logo)
    /// </summary>
    public partial class ContentFormBase : FullScreenFormBase
    {
        [DllImport("user32.dll")]
        //主要API是这个，注意：必须声明为static extern 
        private static extern int ExitWindowsEx(int x, int y); 

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

        /// <summary>
        /// 关机按钮
        /// </summary>
        [Browsable(false)]
        public ImageButton CloseComputerButton { get { return ibCloseComputer; } }

        /// <summary>
        /// 标题文本
        /// </summary>
        public string TitleText
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        /// <summary>
        /// 标题字体
        /// </summary>
        public Font TitleTextFont
        {
            get { return TitleLabel.Font; }
            set { TitleLabel.Font = value; }
        }

        /// <summary>
        /// 标题前景色
        /// </summary>
        public Color TitleTextForeColor
        {
            get { return TitleLabel.ForeColor; }
            set { TitleLabel.ForeColor = value; }
        }

        /// <summary>
        /// 时间字体
        /// </summary>
        public Font TimeTextFont 
        {
            get { return lblTime.Font; }
            set { lblTime.Font = value; }
        }

        /// <summary>
        /// 时间前景色
        /// </summary>
        public Color TimeTextForeColor
        {
            get { return lblTime.ForeColor; }
            set { lblTime.ForeColor = value; }
        }

        /// <summary>
        /// 是否显示时间
        /// </summary>
        public bool EnabledDisplayTime
        {
            get { return trTimeUpdate.Enabled; }
            set { trTimeUpdate.Enabled = value; }
        }

        /// <summary>
        /// 是否显示WifiLogo
        /// </summary>
        public bool EnabledDisplayWifiLogo
        {
            get { return WifiBox.Visible; }
            set { WifiBox.Visible = value; }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        private string _customTimeFormat = "yyyy-MM-dd HH:mm:ss ddd";
        /// <summary>
        /// 自定义时间格式字符串
        /// </summary>
        public string CustomTimeFormat
        {
            get { return _customTimeFormat; }
            set { _customTimeFormat = value; }
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
            lblTime.Text = DateTime.Now.ToString(CustomTimeFormat);
        }

        private void btnCloseComputer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要关机吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                ExitWindowsEx(1, 0); 
            }
        }
    }
}