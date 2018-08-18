using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotSportTaskEditor.Forms
{
    public partial class DeviceEditorForm : Form
    {
        public DeviceEditorForm()
        {
            InitializeComponent();
        }

        public string NickName
        {
            get { return tbNickName.Text; }
            set { tbNickName.Text = value; }
        }

        public string IP
        {
            get { return tbIP.Text; }
            set { tbIP.Text = value; }
        }

        public int Port
        {
            get { return (int)tbPort.Value; }
            set { tbPort.Value = value; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}