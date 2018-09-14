using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class LockUI : PageUIBase
    {
        public LockUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //检查是否存在欢迎图片(./welcome.png)
            if (File.Exists(Path.Combine(Application.StartupPath, "welcome.png")))
            {
                pbFace.Image = MainService.GetImage(Path.Combine(Application.StartupPath, "welcome.png"));
            }

            //查找可以播放的视频
            string[] files = Directory.GetFiles(SuperObject.ReadmeDir);
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            this.Close();
        }

        /// <summary>
        /// 继续循环播放视频
        /// </summary>
        public void UnLock()
        {
            
        }

        /// <summary>
        /// 锁定视频播放,只显示welcome.png
        /// </summary>
        public void Lock()
        {
            
        }
    }
}