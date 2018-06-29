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
        public ContentFormBase()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
    }
}