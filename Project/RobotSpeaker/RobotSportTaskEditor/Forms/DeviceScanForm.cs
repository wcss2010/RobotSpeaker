using RobotFinderLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotSportTaskEditor.Forms
{
    public partial class DeviceScanForm : Form
    {
        private UDPPortScan _udpPortScan = new UDPPortScan();

        /// <summary>
        /// 当前选择列表
        /// </summary>
        public List<RobotConfigItem> SelectedList { get; set; }

        public DeviceScanForm(DeviceListForm deviceListForm)
        {
            InitializeComponent();

            DeviceForm = deviceListForm;
            string lip = _udpPortScan.UdpClient.GetLocalIP();
            string[] ttt = lip.Split('.');
            tbUdpBoardCastIp.Text = ttt[0] + "." + ttt[1] + "." + ttt[2] + ".255";
        }

        public DeviceListForm DeviceForm { get; set; }

        private void btnStartScan_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}