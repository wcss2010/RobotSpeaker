using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Controls.Chat
{
    public partial class ContentPanel : Panel
    {
        /// <summary>
        /// 当前消息气泡起始位置
        /// </summary>
        private int top = 0;

        /// <summary>
        /// 当前消息气泡高度
        /// </summary>
        private int height = 0;

        public ContentPanel()
        {
            InitializeComponent();
            AutoScroll = true;
        }
        
        /// <summary>
        /// 显示接收消息
        /// </summary>
        /// <param name="model"></param>
        private void AddReceiveMessage(string content)
        {
            ContentItem item = new ContentItem();
            item.messageType = ContentItem.MessageType.receive;
            item.SetWeChatContent(content);

            //计算高度
            item.Top = top + height;
            top = item.Top;
            height = item.HEIGHT;

            //滚动条移动最上方，重新计算气泡在panel的位置
            AutoScrollPosition = new Point(0, 0);
            Controls.Add(item);
        }

        // <summary>
        /// 更新界面，显示发送消息
        /// </summary>
        private void AddSendMessage(string content)
        {
            ContentItem item = new ContentItem();
            item.messageType = ContentItem.MessageType.send;
            item.SetWeChatContent(content);
            item.Top = top + height;
            item.Left = (Width - 10) - item.WIDTH;

            top = item.Top;
            height = item.HEIGHT;
            AutoScrollPosition = new Point(0, 0);
            Controls.Add(item);
        }
    }
}