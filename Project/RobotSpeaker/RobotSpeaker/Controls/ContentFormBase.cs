using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Controls
{
    /// <summary>
    /// 内容窗体(带返回按钮和Logo)
    /// </summary>
    public partial class ContentFormBase : FullScreenFormBase
    {
        /// <summary>
        /// 返回按钮
        /// </summary>
        [Browsable(false)]
        public ImageButton BackButton { get { return this.ibBack; } }

        /// <summary>
        /// 标题栏
        /// </summary>
        [Browsable(false)]
        public Label TitleLabel { get { return this.lblTitle; } }

        /// <summary>
        /// Logo
        /// </summary>
        [Browsable(false)]
        public PictureBox LogoBox { get { return this.pbLogo; } }

        /// <summary>
        /// Wifi图标
        /// </summary>
        [Browsable(false)]
        public PictureBox WifiBox { get { return this.pbWifi; } }

        /// <summary>
        /// 标题栏面板
        /// </summary>
        [Browsable(false)]
        public Panel TitlePanel { get { return this.plTopBar; } }

        /// <summary>
        /// 关机按钮
        /// </summary>
        [Browsable(false)]
        public ImageButton CloseComputerButton { get { return ibCloseComputer; } }

        /// <summary>
        /// 标题文本
        /// </summary>
        public string TitleText
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        /// <summary>
        /// 标题字体
        /// </summary>
        public Font TitleTextFont
        {
            get { return TitleLabel.Font; }
            set { TitleLabel.Font = value; }
        }

        /// <summary>
        /// 标题前景色
        /// </summary>
        public Color TitleTextForeColor
        {
            get { return TitleLabel.ForeColor; }
            set { TitleLabel.ForeColor = value; }
        }

        /// <summary>
        /// 时间字体
        /// </summary>
        public Font TimeTextFont 
        {
            get { return lblTime.Font; }
            set { lblTime.Font = value; }
        }

        /// <summary>
        /// 时间前景色
        /// </summary>
        public Color TimeTextForeColor
        {
            get { return lblTime.ForeColor; }
            set { lblTime.ForeColor = value; }
        }

        /// <summary>
        /// 是否显示时间
        /// </summary>
        public bool EnabledDisplayTime
        {
            get { return trTimeUpdate.Enabled; }
            set { trTimeUpdate.Enabled = value; }
        }

        /// <summary>
        /// 是否显示WifiLogo
        /// </summary>
        public bool EnabledDisplayWifiLogo
        {
            get { return WifiBox.Visible; }
            set { WifiBox.Visible = value; }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        private string _customTimeFormat = "yyyy-MM-dd HH:mm:ss ddd";
        /// <summary>
        /// 自定义时间格式字符串
        /// </summary>
        public string CustomTimeFormat
        {
            get { return _customTimeFormat; }
            set { _customTimeFormat = value; }
        }
        
        public ContentFormBase()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void ibBack_Click(object sender, EventArgs e)
        {
            this.OnClickBackButton(e);
        }

        /// <summary>
        /// 返回按钮点击
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnClickBackButton(EventArgs e) { }

        private void trTimeUpdate_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString(CustomTimeFormat);
        }

        private void btnCloseComputer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要关机吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Win32API.DoExitWindows(Win32API.ExitWindows.PowerOff);
            }
        }
    }

    public class Win32API
    {
        private const int SE_PRIVILEGE_ENABLED = 0x00000002;
        private const int TOKEN_QUERY = 0x00000008;
        private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        [Flags]
        public enum ExitWindows : uint
        {
            LogOff = 0x00, //注销
            ShutDown = 0x01, //关机
            Reboot = 0x02, //重启
            Force = 0x04,
            PowerOff = 0x08,
            ForceIfHung = 0x10
        }

        [Flags]
        private enum ShutdownReason : uint
        {
            MajorApplication = 0x00040000,
            MajorHardware = 0x00010000,
            MajorLegacyApi = 0x00070000,
            MajorOperatingSystem = 0x00020000,
            MajorOther = 0x00000000,
            MajorPower = 0x00060000,
            MajorSoftware = 0x00030000,
            MajorSystem = 0x00050000,
            MinorBlueScreen = 0x0000000F,
            MinorCordUnplugged = 0x0000000b,
            MinorDisk = 0x00000007,
            MinorEnvironment = 0x0000000c,
            MinorHardwareDriver = 0x0000000d,
            MinorHotfix = 0x00000011,
            MinorHung = 0x00000005,
            MinorInstallation = 0x00000002,
            MinorMaintenance = 0x00000001,
            MinorMMC = 0x00000019,
            MinorNetworkConnectivity = 0x00000014,
            MinorNetworkCard = 0x00000009,
            MinorOther = 0x00000000,
            MinorOtherDriver = 0x0000000e,
            MinorPowerSupply = 0x0000000a,
            MinorProcessor = 0x00000008,
            MinorReconfig = 0x00000004,
            MinorSecurity = 0x00000013,
            MinorSecurityFix = 0x00000012,
            MinorSecurityFixUninstall = 0x00000018,
            MinorServicePack = 0x00000010,
            MinorServicePackUninstall = 0x00000016,
            MinorTermSrv = 0x00000020,
            MinorUnstable = 0x00000006,
            MinorUpgrade = 0x00000003,
            MinorWMI = 0x00000015,
            FlagUserDefined = 0x40000000,
            FlagPlanned = 0x80000000
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll")]
        private static extern bool ExitWindowsEx(ExitWindows uFlags, ShutdownReason dwReason);

        /// <summary>
        /// 关机、重启、注销windows
        /// </summary>
        /// <param name="flag"></param>
        public static void DoExitWindows(ExitWindows flag)
        {
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ExitWindowsEx(flag, ShutdownReason.MajorOther);
        }
    }
}