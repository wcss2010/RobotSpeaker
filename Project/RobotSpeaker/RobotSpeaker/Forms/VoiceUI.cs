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
        public VoiceUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cpChatContent.AddRecvMsg("收到消息！！！");
            cpChatContent.AddSendMsg("消息发出！！！");

            cpChatContent.AddRecvMsg("收到消息！！！");
            cpChatContent.AddSendMsg("消息发出！！！");

            cpChatContent.AddRecvMsg("收到消息！！！");
            cpChatContent.AddSendMsg("消息发出！！！");
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }
    }
}