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
    /// 全屏窗体基类
    /// </summary>
    public partial class FullScreenFormBase : Form
    {
        public FullScreenFormBase()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);//防止窗口跳动
            SetStyle(ControlStyles.DoubleBuffer, true); //防止控件跳动 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //窗体全屏
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }
    }
}