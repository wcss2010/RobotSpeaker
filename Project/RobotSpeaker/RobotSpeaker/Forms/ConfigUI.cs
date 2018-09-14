using RobotSpeaker.Forms.JoyAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class ConfigUI : Form
    {
        /// <summary>
        /// 手柄按键状态
        /// </summary>
        public JoystickStateInfo JoystickStateInfo { get { return jsijoystickInfo; } }

        public ConfigUI()
        {
            InitializeComponent();

            MainService.ConfigUIObj = this;

            foreach (string port in System.IO.Ports.SerialPort.GetPortNames())
            {
                cbOnlineVoicePort.Items.Add(port);
                cbOfflineVoicePort.Items.Add(port);
                cbGoPort.Items.Add(port);
            }

            if (cbOnlineVoicePort.Items.Count > 0)
            {
                cbOnlineVoicePort.SelectedIndex = 0;
                cbOfflineVoicePort.SelectedIndex = 0;
                cbGoPort.SelectedIndex = 0;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadFromConfig();

            ShowDebugServiceInfo();
        }

        /// <summary>
        /// 显示调试服务信息
        /// </summary>
        private void ShowDebugServiceInfo()
        {
            try
            {
                lblDebug1.Text = "本机IP：" + MainService.DebugService.ListenIP;
                lblDebug2.Text = "本地端口：" + MainService.DebugService.ListenPort;
                lblDebug3.Text = "在线连接数量：" + MainService.DebugService.DebugSocketServer.Connections.Count;
            }
            catch (Exception ex) { }
        }

        private void LoadFromConfig()
        {
            cbEnabledSwitchToLockUIOnStartup.Checked = SuperObject.Config.EnabledSwitchToLockUIOnStartup;
            cbEnabledOfflineVoice.Checked = !SuperObject.Config.EnabledOnlineVoice;
            tbDebugHintText.Text = SuperObject.Config.DebugModeHintText;
            tbVoiceWelcomeText.Text = SuperObject.Config.VoiceWelcomeText;
            tbPassword.Text = SuperObject.Config.ManagerPassword;
            tbWebSiteUrl.Text = SuperObject.Config.WebSiteUrl;
            tbGoAppPath.Text = SuperObject.Config.GoAppPath;
            cbOnlineVoicePort.Text = SuperObject.Config.OnlineVoicePort;
            cbOfflineVoicePort.Text = SuperObject.Config.OfflineVoicePort;
            cbGoPort.Text = SuperObject.Config.GoPort;
            tbImageListPlayerSleepSeconds.Value = SuperObject.Config.ImageListPlayerSleepSeconds;
            cbEnabledOnlineVoice.Checked = SuperObject.Config.EnabledOnlineVoice;
            cbEnabledCloseVideoPlayerWithVoice.Checked = SuperObject.Config.EnabledCloseVideoPlayerWithVoice;
            tbOfflineVoiceWebSocketUrl.Text = SuperObject.Config.OfflineVoiceWebSocketUrl;
            ParseOfflineVoiceUrl();

            switch (SuperObject.Config.CurrentGoType)
            {
                case GoType.Normal:
                    clbGoTypes.SetItemChecked(0, true);
                    break;
                case GoType.Joy:
                    clbGoTypes.SetItemChecked(1, true);
                    break;
                case GoType.Free:
                    clbGoTypes.SetItemChecked(2, true);
                    break;

                default:
                    clbGoTypes.SetItemChecked(0, true);
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveToConfig())
            {
                //保存配置
                SuperObject.SaveConfig();

                //重置本地服务
                ResetDataService();

                MessageBox.Show("保存完成");
                Close();
            }
        }

        private bool SaveToConfig()
        {
            if (string.IsNullOrEmpty(tbWebSiteUrl.Text))
            {
                MessageBox.Show("对不起，首页不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(tbGoAppPath.Text))
            {
                MessageBox.Show("对不起，RobotStudio启动路径不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(tbVoiceWelcomeText.Text))
            {
                MessageBox.Show("对不起，欢迎词不能为空！");
                return false;
            }

            SuperObject.Config.EnabledSwitchToLockUIOnStartup = cbEnabledSwitchToLockUIOnStartup.Checked;
            SuperObject.Config.DebugModeHintText = tbDebugHintText.Text;
            SuperObject.Config.EnabledCloseVideoPlayerWithVoice = cbEnabledCloseVideoPlayerWithVoice.Checked; 
            SuperObject.Config.EnabledOnlineVoice = cbEnabledOnlineVoice.Checked;
            SuperObject.Config.ImageListPlayerSleepSeconds = (int)tbImageListPlayerSleepSeconds.Value;
            SuperObject.Config.VoiceWelcomeText = tbVoiceWelcomeText.Text;
            SuperObject.Config.ManagerPassword = tbPassword.Text;
            SuperObject.Config.WebSiteUrl = tbWebSiteUrl.Text;
            SuperObject.Config.GoAppPath = tbGoAppPath.Text;
            SuperObject.Config.OnlineVoicePort = cbOnlineVoicePort.Text;
            SuperObject.Config.OfflineVoicePort = cbOfflineVoicePort.Text;
            SuperObject.Config.GoPort = cbGoPort.Text;
            SuperObject.Config.OfflineVoiceWebSocketUrl = tbOfflineVoiceWebSocketUrl.Text;

            if (clbGoTypes.GetItemChecked(0))
            {
                SuperObject.Config.CurrentGoType = GoType.Normal;
            }
            else if (clbGoTypes.GetItemChecked(1))
            {
                SuperObject.Config.CurrentGoType = GoType.Joy;
            }
            else if (clbGoTypes.GetItemChecked(2))
            {
                SuperObject.Config.CurrentGoType = GoType.Free;
            }
            else
            {
                SuperObject.Config.CurrentGoType = GoType.Normal;
            }

            return true;
        }

        private void btnReadmeDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", SuperObject.ReadmeDir);
            }
            catch (Exception ex) { }
        }

        private void btnCameraDir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", SuperObject.CameraDir);
            }
            catch (Exception ex) { }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (ofdApp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbGoAppPath.Text = ofdApp.FileName;
            }
        }

        private void clbGoTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int k = 0; k < clbGoTypes.Items.Count; k++)
                {
                    if (k == e.Index)
                    {
                        continue;
                    }
                    else
                    {
                        clbGoTypes.SetItemChecked(k, false);
                    }
                }
            }
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要退出吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnInitAIUI_Click(object sender, EventArgs e)
        {
            DeviceDebugUI aiui = new DeviceDebugUI();
            aiui.ShowDialog();
        }

        private void btnRestartService_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要进行吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //重置本地服务
                ResetDataService();
            }
        }
        
        /// <summary>
        /// 重置本地服务
        /// </summary>
        private void ResetDataService()
        {
            MainService.Reset();
        }

        private void cbEnabledOnlineVoice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnabledOnlineVoice.Checked)
            {
                cbEnabledOfflineVoice.Checked = !cbEnabledOnlineVoice.Checked;
            }
        }

        private void cbEnabledOfflineVoice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnabledOfflineVoice.Checked)
            {
                cbEnabledOnlineVoice.Checked = !cbEnabledOfflineVoice.Checked;
            }
        }

        private void tbOfflineVoiceIP_TextChanged(object sender, EventArgs e)
        {
            tbOfflineVoiceWebSocketUrl.Text = MakeOfflineVoiceUrl();
        }

        private void rbOfflineVoiceFeiFei_CheckedChanged(object sender, EventArgs e)
        {
            tbOfflineVoiceWebSocketUrl.Text = MakeOfflineVoiceUrl();
        }

        public string MakeOfflineVoiceUrl()
        {
            string ip = tbOfflineVoiceIP.Text;
            int port = (int)tbOfflineVoicePort.Value;
            string roleName = rbOfflineVoiceFeiFei.Checked ? "feifei" : "yuanyuan";
            StringBuilder sb = new StringBuilder();
            sb.Append("ws://").Append(ip).Append(":").Append(port).Append("/talking/offline/v1/").Append(roleName);
            return sb.ToString();
        }

        private void tbOfflineVoicePort_ValueChanged(object sender, EventArgs e)
        {
            tbOfflineVoiceWebSocketUrl.Text = MakeOfflineVoiceUrl();
        }

        public void ParseOfflineVoiceUrl()
        {
            if (string.IsNullOrEmpty(SuperObject.Config.OfflineVoiceWebSocketUrl))
            {
                return;
            }

            try
            {
                string[] urlConfigs = SuperObject.Config.OfflineVoiceWebSocketUrl.Split('/');
                string[] ips = urlConfigs[2].Split(':');
                tbOfflineVoiceIP.Text = ips[0];
                tbOfflineVoicePort.Value = int.Parse(ips[1]);
                
                string roleName = urlConfigs[urlConfigs.Length -1];
                if (roleName.Equals("feifei"))
                {
                    rbOfflineVoiceFeiFei.Checked = true;
                }
                else
                {
                    rbOfflineVoiceYuanYuan.Checked = true;
                }
            }
            catch (Exception ex) { }
        }

        private void trDebugConnectionsInfos_Tick(object sender, EventArgs e)
        {
            ShowDebugServiceInfo();

            try
            {
                lvConnectionList.Items.Clear();

                foreach (SocketLibrary.Connection conn in MainService.DebugService.DebugSocketServer.Connections.Values)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = conn.NickName;
                    lvi.SubItems.Add(conn.ConnectionName);

                    lvConnectionList.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        private void btnSetWelcomeImage_Click(object sender, EventArgs e)
        {

        }
    }
}