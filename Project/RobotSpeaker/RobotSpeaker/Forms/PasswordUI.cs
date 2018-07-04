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
    public partial class PasswordUI : Form
    {
        public TextBox TextObj
        {
            get { return tbText; }
        }

        public PasswordUI()
        {
            InitializeComponent();

            TextObj.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnOK.PerformClick();
            }
        }
    }
}