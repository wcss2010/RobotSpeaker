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

            cpChatContent.AddMachineMsg("请问我能帮您做什么？");
            cpChatContent.AddUserMsg("今天天气如何？");

            cpChatContent.AddMachineMsg("不知道啊，你自己看看天不就知道了");
            cpChatContent.AddUserMsg("那我还用你干嘛？");

            cpChatContent.AddMachineMsg("说的也是哦。。。我帮您看看哈");
            cpChatContent.AddUserMsg("好的，快点啊");
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }
    }
}