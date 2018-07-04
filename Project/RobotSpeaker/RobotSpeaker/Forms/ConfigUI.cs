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
        public ConfigUI()
        {
            InitializeComponent();

            foreach (string port in System.IO.Ports.SerialPort.GetPortNames())
            {
                cbVoicePort.Items.Add(port);
                cbGoPort.Items.Add(port);
            }

            if (cbVoicePort.Items.Count > 0)
            {
                cbVoicePort.SelectedIndex = 0;
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
            tbPassword.Text = SuperObject.Config.ManagerPassword;
            tbWebSiteUrl.Text = SuperObject.Config.WebSiteUrl;
            tbGoAppPath.Text = SuperObject.Config.GoAppPath;
            cbVoicePort.Text = SuperObject.Config.VoicePort;
            cbGoPort.Text = SuperObject.Config.GoPort;

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
                SuperObject.SaveConfig();
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

            SuperObject.Config.ManagerPassword = tbPassword.Text;
            SuperObject.Config.WebSiteUrl = tbWebSiteUrl.Text;
            SuperObject.Config.GoAppPath = tbGoAppPath.Text;
            SuperObject.Config.VoicePort = cbVoicePort.Text;
            SuperObject.Config.GoPort = cbGoPort.Text;

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
    }
}