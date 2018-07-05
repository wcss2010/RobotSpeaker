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
            DataService.VoiceUIObj = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ChatPanel.AddMachineMsg("您好，我有什么能够帮你");
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }
    }
}