using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class InputUI : Form
    {
        public string Input
        {
            get { return tbContent.Text; }
        }

        public InputUI(string titleStr,string defaultStr)
        {
            InitializeComponent();

            //设置初始值
            Text = titleStr;
            tbContent.Text = defaultStr;

            //文本框获得焦点
            tbContent.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tbContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnOK.PerformClick();
            }
        }
    }
}