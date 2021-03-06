﻿using AIUISerials;
using NativeWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class DeviceDebugUI : Form
    {
        /// <summary>
        /// 语音卡AppId配置项
        /// </summary>
        public const string CONFIG_ID_APPID = "Voice_AppId";
        /// <summary>
        /// 语音卡AppKey配置项
        /// </summary>
        public const string CONFIG_ID_APPKEY = "Voice_AppKey";
        /// <summary>
        /// 语音卡情景模式配置项
        /// </summary>
        public const string CONFIG_ID_Scene = "Voice_Scene";

        private string WillWifiSSID { get; set; }
        private string WillWifiPassword { get; set; }

        private List<WIFISSID> ssids;
        private wifiSo wifiso;
        private int debugLogLineCount = 0;

        public DeviceDebugUI()
        {
            InitializeComponent();

            MainService.DeviceDebugUIObj = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.lvWifiList.Columns.Add("wifi名称", 160, HorizontalAlignment.Left); //一步添加 
            this.lvWifiList.Columns.Add("wifiSSID", 120, HorizontalAlignment.Left); //一步添加 
            this.lvWifiList.Columns.Add("加密方式", 100, HorizontalAlignment.Left); //一步添加
            this.lvWifiList.Columns.Add("信号强度", 88, HorizontalAlignment.Left); //一步添加 
            //ColumnHeader ch = new ColumnHeader();  //先创建列表头
            lvWifiList.GridLines = true;//显示网格
            lvWifiList.Scrollable = true;//显示所有项时是否显示滚动条
            lvWifiList.AllowColumnReorder = true;
            lvWifiList.FullRowSelect = true;
            lvWifiList.CheckBoxes = false;

            wifiso = new wifiSo();  //加载wifi
            ssids = wifiso.ssids;
            wifiso.ScanSSID();      //显示所有wifi

            btnRefreshWifiList.PerformClick();

            tbAppId.Text = SuperObject.Config.GetValue<string>(CONFIG_ID_APPID);
            tbAppKey.Text = SuperObject.Config.GetValue<string>(CONFIG_ID_APPKEY);
            tbScene.Text = string.IsNullOrEmpty(SuperObject.Config.GetValue<string>(CONFIG_ID_Scene)) ? "main" : SuperObject.Config.GetValue<string>(CONFIG_ID_Scene);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="wifiname"></param>
        /// <param name="pass"></param>
        /// <param name="dot11DefaultAuthAlgorithm"></param>
        /// <param name="i"></param>
        private void wifiListOKADDitem(String wifiname, String pass, String dot11DefaultAuthAlgorithm, int i)
        {
            this.lvWifiList.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
            //this.wifiListOK.Items.Add(wifiname,0);
            ListViewItem wifiitem = lvWifiList.Items.Add(wifiname);

            wifiitem.SubItems.Add(pass);
            wifiitem.SubItems.Add(dot11DefaultAuthAlgorithm);
            wifiitem.SubItems.Add(i + "");

            this.lvWifiList.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            this.lvWifiList.View = System.Windows.Forms.View.Details;
        }

        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.UTF8.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }
        
        /// <summary>
        /// 显示所有wifi
        /// </summary>
        public void ScanSSID()
        {
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all networks with WEP security
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    WIFISSID targetSSID = new WIFISSID();

                    targetSSID.wlanInterface = wlanIface;
                    targetSSID.wlanSignalQuality = (int)network.wlanSignalQuality;
                    targetSSID.SSID = GetStringForSSID(network.dot11Ssid);
                    //targetSSID.SSID = Encoding.Default.GetString(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength);
                    targetSSID.dot11DefaultAuthAlgorithm = network.dot11DefaultAuthAlgorithm.ToString();
                    targetSSID.dot11DefaultCipherAlgorithm = network.dot11DefaultCipherAlgorithm.ToString();
                    ssids.Add(targetSSID);
                    wifiListOKADDitem(GetStringForSSID(network.dot11Ssid), network.dot11DefaultCipherAlgorithm.ToString(),
                        network.dot11DefaultAuthAlgorithm.ToString(), (int)network.wlanSignalQuality);

                    if (GetStringForSSID(network.dot11Ssid).Equals(WillWifiSSID))
                    {
                        var obj = new wifiSo(targetSSID, WillWifiPassword);
                        Thread wificonnect = new Thread(obj.ConnectToSSID);
                        wificonnect.Start();
                        //wifiso.ConnectToSSID(targetSSID, "ZMZGZS520");//连接wifi
                        ShowCurrentWifiName(GetStringForSSID(network.dot11Ssid));
                    }
                }
            }
        }

        protected void ShowCurrentWifiName(string ssid)
        {
            lblCurrentWifiName.Text = "当前Wifi:" + ssid;
        }

        private void btnRefreshWifiList_Click(object sender, EventArgs e)
        {
            lvWifiList.Items.Clear();  //只移除所有的项。
            ScanSSID();
        }

        private void btnConnectWifi_Click(object sender, EventArgs e)
        {

        }

        private void btnDisconnectWifi_Click(object sender, EventArgs e)
        {

        }

        private void lvWifiList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvWifiList.SelectedIndices != null && lvWifiList.SelectedItems.Count > 0)
            {
                ListView.SelectedIndexCollection c = lvWifiList.SelectedIndices;
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要连接" + lvWifiList.Items[c[0]].Text + "吗?", "wifi连接", messButton);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    string pwd = "";
                    PasswordUI pwdInput = new PasswordUI();

                    if (pwdInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //取输入的密码
                        pwd = pwdInput.TextObj.Text;

                        //连接wifi
                        try
                        {
                            ConnectToWifi(lvWifiList.Items[c[0]].SubItems[2].Text, lvWifiList.Items[c[0]].Text, pwd);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("连接wifi出错！");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 连接到wifi
        /// </summary>
        /// <param name="ssid"></param>
        /// <param name="pwd"></param>
        private void ConnectToWifi(string encryptType,string ssid, string pwd)
        {
            //windows连接到wifi
            WindowsConnectToWifi(encryptType,ssid, pwd);

            //aiui连接到wifi
            AIUIConnectToWifi(encryptType,ssid, pwd);
        }

        /// <summary>
        /// 连接到wifi(Windows)
        /// </summary>
        /// <param name="ssid"></param>
        /// <param name="pwd"></param>
        private void WindowsConnectToWifi(string encryptType, string ssid, string pwd)
        {
            //设置要连接的wifi
            WillWifiSSID = ssid;
            WillWifiPassword = pwd;

            //扫描并连接wifi
            ScanSSID();

            //清空连接设置
            WillWifiSSID = "";
            WillWifiPassword = "";
        }

        /// <summary>
        /// 连接到wifi(AIUI)
        /// </summary>
        /// <param name="ssid"></param>
        /// <param name="pwd"></param>
        private void AIUIConnectToWifi(string encryptType, string ssid, string pwd)
        {
            MainService.AiuiOnlineService.AiuiConnection.ConfigWifiMessage(ssid + "|" + pwd + "|" + WifiEncryptType.WPA);
        }

        /// <summary>
        /// 打印调试日志
        /// </summary>
        /// <param name="message"></param>
        public void PrintDebugLog(string message)
        {
            if (IsHandleCreated)
            {
                try
                {
                    Invoke(new MethodInvoker(delegate()
                        {
                            try
                            {
                                debugLogLineCount++;
                                if (debugLogLineCount >= 100)
                                {
                                    debugLogLineCount = 0;
                                    tbDebugLog.Text = "";
                                }

                                tbDebugLog.AppendText(message + "\n");
                                tbDebugLog.Select(tbDebugLog.Text.Length, 0);
                                tbDebugLog.ScrollToCaret();
                            }
                            catch (Exception ex) { }
                        }));
                }
                catch (Exception ex) { }
            }
        }

        private void btnGetAIUIWifi_Click(object sender, EventArgs e)
        {
            MainService.AiuiOnlineService.AiuiConnection.SendCmd(CommandConst.QUERY_WIFI_STATE);
        }

        private void btnAIUIConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAppId.Text))
            {
                MessageBox.Show("对不起，请输入AppId!");
                return;
            }
            if (string.IsNullOrEmpty(tbAppKey.Text))
            {
                MessageBox.Show("对不起，请输入AppKey!");
                return;
            }
            if (string.IsNullOrEmpty(tbScene.Text))
            {
                MessageBox.Show("对不起，请输入情景模式!");
                return;
            }

            if (MessageBox.Show("真的要进行吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //保存配置
                SuperObject.Config.SetValue<string>(CONFIG_ID_APPID, tbAppId.Text.Trim());
                SuperObject.Config.SetValue<string>(CONFIG_ID_APPKEY, tbAppKey.Text.Trim());
                SuperObject.Config.SetValue<string>(CONFIG_ID_Scene, tbScene.Text.Trim());
                SuperObject.SaveConfig();

                //设置AIUI属性
                string configStr = tbAppId.Text.Trim() + "|" + tbAppKey.Text.Trim() + "|" + tbScene.Text.Trim() + "|" + cbIsEnabledUseAIUIAfter.CheckState;
                MainService.AiuiOnlineService.AiuiConnection.SendAIUIConfigMessage(configStr.Trim());
            }
        }

        private void btnGetWakeupState_Click(object sender, EventArgs e)
        {
            MainService.AiuiOnlineService.AiuiConnection.SendCmd(CommandConst.QUERY_AIUI_STATE);
        }

        private void btnWakeup_Click(object sender, EventArgs e)
        {
            MainService.AiuiOnlineService.AiuiConnection.SendWakeUpMessage(false);
        }

        private void btnTTSRead_Click(object sender, EventArgs e)
        {
            InputUI inputBox = new InputUI("请输入要合成的文本:", string.Empty);
            if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (inputBox.Input.Trim() != string.Empty)
                {
                    MainService.AiuiOnlineService.AiuiConnection.SendTTSMessage(inputBox.Input);
                }
            }
        }

        private void btnStartVoice_Click(object sender, EventArgs e)
        {
            MainService.AiuiOnlineService.AiuiConnection.SendLauchVoiceMessage(true);
        }

        private void btnStopVoice_Click(object sender, EventArgs e)
        {
            MainService.AiuiOnlineService.AiuiConnection.SendLauchVoiceMessage(false);
        }

        private void btnResetWakeup_Click(object sender, EventArgs e)
        {
            MainService.AiuiOnlineService.AiuiConnection.SendWakeUpMessage(true);
        }
    }

    /// <summary>
    /// WIFI加密方式
    /// </summary>
    public enum WifiEncryptType
    {
        WPA, WEP, NONE
    }

    class wifiSo
    {
        private WIFISSID ssid;               //wifi ssid
        private string key;                 //wifi密码
        public List<WIFISSID> ssids = new List<WIFISSID>();

        public wifiSo()
        {
            ssids.Clear();
        }

        public wifiSo(WIFISSID ssid, string key)
        {
            ssids.Clear();
            this.ssid = ssid;
            this.key = key;
        }

        //寻找当前连接的网络：
        public static string GetCurrentConnection()
        {
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    if (wlanIface.InterfaceState == Wlan.WlanInterfaceState.Connected && wlanIface.CurrentConnection.isState == Wlan.WlanInterfaceState.Connected)
                    {
                        return wlanIface.CurrentConnection.profileName;
                    }
                }
            }

            return string.Empty;
        }
        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.UTF8.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }
        /// <summary>
        /// 枚举所有无线设备接收到的SSID
        /// </summary>
        public void ScanSSID()
        {
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all networks with WEP security
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    WIFISSID targetSSID = new WIFISSID();

                    targetSSID.wlanInterface = wlanIface;
                    targetSSID.wlanSignalQuality = (int)network.wlanSignalQuality;
                    targetSSID.SSID = GetStringForSSID(network.dot11Ssid);
                    //targetSSID.SSID = Encoding.Default.GetString(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength);
                    targetSSID.dot11DefaultAuthAlgorithm = network.dot11DefaultAuthAlgorithm.ToString();
                    targetSSID.dot11DefaultCipherAlgorithm = network.dot11DefaultCipherAlgorithm.ToString();
                    ssids.Add(targetSSID);
                }
            }
        }

        // 字符串转Hex
        public static string StringToHex(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.Default.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString().ToUpper());

        }

        // 连接到无线网络
        public void ConnectToSSID()
        {
            try
            {
                String auth = string.Empty;
                String cipher = string.Empty;
                bool isNoKey = false;
                String keytype = string.Empty;
                //Console.WriteLine("》》》《《" + ssid.dot11DefaultAuthAlgorithm + "》》对比《《" + "Wlan.Dot11AuthAlgorithm.RSNA_PSK》》");
                switch (ssid.dot11DefaultAuthAlgorithm)
                {
                    case "IEEE80211_Open":
                        auth = "open"; break;
                    case "RSNA":
                        auth = "WPA2PSK"; break;
                    case "RSNA_PSK":
                        //Console.WriteLine("电子设计wifi：》》》");
                        auth = "WPA2PSK"; break;
                    case "WPA":
                        auth = "WPAPSK"; break;
                    case "WPA_None":
                        auth = "WPAPSK"; break;
                    case "WPA_PSK":
                        auth = "WPAPSK"; break;
                }
                switch (ssid.dot11DefaultCipherAlgorithm)
                {
                    case "CCMP":
                        cipher = "AES";
                        keytype = "passPhrase";
                        break;
                    case "TKIP":
                        cipher = "TKIP";
                        keytype = "passPhrase";
                        break;
                    case "None":
                        cipher = "none"; keytype = "";
                        isNoKey = true;
                        break;
                    case "WWEP":
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                    case "WEP40":
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                    case "WEP104":
                        cipher = "WEP";
                        keytype = "networkKey";
                        break;
                }

                if (isNoKey && !string.IsNullOrEmpty(key))
                {

                    Console.WriteLine(">>>>>>>>>>>>>>>>>无法连接网络！");
                    return;
                }
                else if (!isNoKey && string.IsNullOrEmpty(key))
                {
                    Console.WriteLine("无法连接网络！");
                    return;
                }
                else
                {
                    //string profileName = ssid.profileNames; // this is also the SSID 
                    string profileName = ssid.SSID;
                    string mac = StringToHex(profileName);
                    string profileXml = string.Empty;
                    if (!string.IsNullOrEmpty(key))
                    {
                        profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><connectionMode>auto</connectionMode><autoSwitch>false</autoSwitch><MSM><security><authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption><sharedKey><keyType>{4}</keyType><protected>false</protected><keyMaterial>{5}</keyMaterial></sharedKey><keyIndex>0</keyIndex></security></MSM></WLANProfile>",
                            profileName, mac, auth, cipher, keytype, key);
                    }
                    else
                    {
                        profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><connectionMode>auto</connectionMode><autoSwitch>false</autoSwitch><MSM><security><authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption></security></MSM></WLANProfile>",
                            profileName, mac, auth, cipher, keytype);
                    }

                    ssid.wlanInterface.SetProfile(Wlan.WlanProfileFlags.AllUser, profileXml, true);

                    bool success = ssid.wlanInterface.ConnectSynchronously(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName, 15000);
                    if (!success)
                    {
                        Console.WriteLine("连接网络失败！");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("连接网络失败！");
                return;
            }
        }
        //当连接的连接状态进行通知 面是简单的通知事件的实现，根据通知的内容在界面上显示提示信息：
        private void WlanInterface_WlanConnectionNotification(Wlan.WlanNotificationData notifyData, Wlan.WlanConnectionNotificationData connNotifyData)
        {
            try
            {
                if (notifyData.notificationSource == Wlan.WlanNotificationSource.ACM)
                {
                    int notificationCode = (int)notifyData.NotificationCode;
                    switch (notificationCode)
                    {
                        case (int)Wlan.WlanNotificationCodeAcm.ConnectionStart:

                            Console.WriteLine("开始连接无线网络.......");
                            break;
                        case (int)Wlan.WlanNotificationCodeAcm.ConnectionComplete:

                            break;
                        case (int)Wlan.WlanNotificationCodeAcm.Disconnecting:

                            Console.WriteLine("正在断开无线网络连接.......");
                            break;
                        case (int)Wlan.WlanNotificationCodeAcm.Disconnected:
                            Console.WriteLine("已经断开无线网络连接.......");
                            break;
                    }
                }
                //}));
            }
            catch (Exception e)
            {
                //Loger.WriteLog(e.Message);
            }
        }
    }
    
    class WIFISSID
    {
        public string SSID = "NONE";
        public string dot11DefaultAuthAlgorithm = "";
        public string dot11DefaultCipherAlgorithm = "";
        public bool networkConnectable = true;
        public string wlanNotConnectableReason = "";
        public int wlanSignalQuality = 0;
        public WlanClient.WlanInterface wlanInterface = null;
    }
}