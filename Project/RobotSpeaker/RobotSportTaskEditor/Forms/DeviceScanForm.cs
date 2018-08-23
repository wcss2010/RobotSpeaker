using RobotFinderLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
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

        private List<RobotConfigItem> totalRobotList = new List<RobotConfigItem>(); 

        public DeviceScanForm(DeviceListForm deviceListForm)
        {
            InitializeComponent();

            DeviceListF = deviceListForm;

            #region 广播地址
            string lip = _udpPortScan.UdpClient.GetLocalIP();
            string[] ttt = lip.Split('.');
            tbUdpBoardCastIp.Text = ttt[0] + "." + ttt[1] + "." + ttt[2] + ".255";
            #endregion

            _udpPortScan.RobotResponseEvent += _udpPortScan_RobotResponseEvent;
            _udpPortScan.StartEvent += _udpPortScan_StartEvent;
            _udpPortScan.StopEvent += _udpPortScan_StopEvent;
            _udpPortScan.ProgressEvent += _udpPortScan_ProgressEvent;
        }

        void _udpPortScan_ProgressEvent(object sender, RobotFinderLibrary.ProgressEventArgs args)
        {

        }

        void _udpPortScan_StopEvent(object sender, EventArgs args)
        {
            try
            {
                Thread.Sleep(8000);
            }
            catch (Exception ex) { }

            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    btnStartScan.Enabled = true;
                }));
            }
        }

        void _udpPortScan_StartEvent(object sender, EventArgs args)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                    {
                        btnStartScan.Enabled = false;
                    }));
            }
        }

        void _udpPortScan_RobotResponseEvent(object sender, RobotFinderLibrary.ProgressEventArgs args)
        {
            #region 记录这个IP
            if (string.IsNullOrEmpty(args.ResponseText))
            {
                return;
            }

            string[] tt = args.ResponseText.Replace("Robot_", string.Empty).Split(':');
            if (tt != null && tt.Length >= 2)
            {
                try
                {
                    RobotConfigItem rci = new RobotConfigItem();
                    rci.NickName = args.ResponseText;
                    rci.IP = tt[0];
                    rci.Port = int.Parse(tt[1]);
                    totalRobotList.Add(rci);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
            #endregion

            //刷新列表
            UpdateConnectionList();
        }

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void UpdateConnectionList()
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                    {
                        lvConnectionList.Items.Clear();

                        foreach (RobotConfigItem rcii in totalRobotList)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = rcii.NickName;
                            lvi.SubItems.Add(rcii.IP);
                            lvi.SubItems.Add(rcii.Port + "");

                            lvi.Tag = rcii;

                            lvConnectionList.Items.Add(lvi);
                        }
                    }));
            }
        }

        public DeviceListForm DeviceListF { get; set; }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (_udpPortScan.UdpClient.LocalUdpPort <= 0)
            {
                _udpPortScan.UdpClient.OpenListener();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //停止扫描
            _udpPortScan.StopScan();

            //关闭监听
            try
            {
                _udpPortScan.UdpClient.CloseListener();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            _udpPortScan.ResultDict.Clear();
            _udpPortScan.InitQueues(tbUdpBoardCastIp.Text.Trim(), 5000, 6000);
            _udpPortScan.StartScan();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedList = new List<RobotConfigItem>();
            foreach (ListViewItem lvi in lvConnectionList.Items)
            {
                if (lvi.Checked)
                {
                    SelectedList.Add((RobotConfigItem)lvi.Tag);
                }
            }

            if (SelectedList.Count == 0)
            {
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}