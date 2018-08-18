using AIUISerials;
using RobotSpeaker.Controls.Chat;
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
    public partial class VoiceUI : PageUIBase
    {
        /// <summary>
        /// 聊天面板
        /// </summary>
        public ContentPanel ChatPanel { get { return cpChatContent; } }

        public VoiceUI()
        {
            InitializeComponent();

            //保存引用
            MainService.VoiceUIObj = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //显示欢迎信息
            ChatPanel.AddMachineMsg(SuperObject.Config.VoiceWelcomeText);

            //查询Wifi状态
            if (MainService.AiuiOnlineService.AiuiConnection.SerialPort.IsConnected)
            {
                MainService.AiuiOnlineService.AiuiConnection.SendCmd(CommandConst.QUERY_WIFI_STATE);
            }

            TitleText = "语音对话(" + (SuperObject.Config.EnabledOnlineVoice ? "在线对话模式" : "离线对话模式") + (MainService.TaskService.RunMode == RunModeType.Debug ? "_调试状态" : "") + ")";
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }
    }
}