using RobotSpeaker.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class PageUIBase : ContentFormBase
    {
        private int OfflineCount = 0;

        public PageUIBase()
        {
            InitializeComponent();

            LockButton.Click += LockButton_Click;
        }

        void LockButton_Click(object sender, EventArgs e)
        {
            if (GetType().FullName.Equals(typeof(LockUI).FullName))
            {
                return;
            }
            else
            {
                new LockUI().Show();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            TitleTextForeColor = Color.White;
            TimeTextForeColor = Color.White;
            try
            {
                BackButton.NoFocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\back1.png"));
                BackButton.FocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\back2.png"));
                CloseComputerButton.NoFocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\power1.png"));
                CloseComputerButton.FocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\power2.png"));
                LockButton.NoFocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\welcome1.png"));
                LockButton.FocusImage = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\welcome2.png"));
                LogoBox.Image = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\logo.png"));
                WifiBox.Image = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\offline.jpg"));
            }
            catch (Exception ex) { }

            //设置在线
            IsOnline(true);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            //屏掉alt+f4
            if ((e.KeyCode == Keys.F4) && (e.Alt == true))
            {
                e.Handled = true;
            }
        }

        private void trNetworkStatusUpdate_Tick(object sender, EventArgs e)
        {
            if (PingIpOrDomainName("www.baidu.com"))
            {
                OfflineCount = 0;
                IsOnline(true);
            }
            else
            {
                OfflineCount++;
            }

            if (OfflineCount >= 8)
            {
                IsOnline(false);
            }
        }

        /// <summary>
        /// 设置在线状态图标
        /// </summary>
        /// <param name="isOnline"></param>
        protected void IsOnline(bool isOnline)
        {
            if (isOnline)
            {
                WifiBox.Image = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\online.jpg"));
            }
            else
            {
                WifiBox.Image = MainService.GetImage(Path.Combine(Application.StartupPath, @"Images\offline.jpg"));
            }
        }

        /// <summary>
        /// 用于检查IP地址或域名是否可以使用TCP/IP协议访问(使用Ping命令),true表示Ping成功,false表示Ping失败
        /// </summary>
        /// <param name="strIpOrDName">输入参数,表示IP地址或域名</param>
        /// <returns></returns>
        public static bool PingIpOrDomainName(string strIpOrDName)
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions();
                objPinOptions.DontFragment = true;
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 120;
                PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}