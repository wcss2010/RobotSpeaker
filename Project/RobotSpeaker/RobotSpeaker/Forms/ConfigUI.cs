using RobotSpeaker.Forms.JoyAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        }

        private void LoadFromConfig()
        {
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
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("对不起，密码不能为空！");
                return false;
            }
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
    }
}