using RobotSpeaker.Forms.Player;
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
        /// <summary>
        /// AIUI状态(talk=对话状态,listen=监听状态)
        /// </summary>
        public static string AIUIStatus = "listen";

        private List<string> videoFiles = new List<string>();

        public LockUI()
        {
            InitializeComponent();

            MainService.LockUIObj = this;
            vpcPlayer.StopEvent += vpcPlayer_StopEvent;
        }

        void vpcPlayer_StopEvent(object sender, EventArgs args)
        {
            if (vpcPlayer.Visible)
            {
                int videoIndex = videoFiles.IndexOf(vpcPlayer.MediaUrl);
                if (videoIndex >= videoFiles.Count - 1)
                {
                    vpcPlayer.SetMediaUrl(videoFiles[0]);
                }
                else
                {
                    vpcPlayer.SetMediaUrl(videoFiles[videoIndex + 1]);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //初始化播放器
            vpcPlayer.InitPlayer();

            //检查是否存在欢迎图片(./welcome.png)
            if (File.Exists(Path.Combine(Application.StartupPath, "welcome.png")))
            {
                pbFace.Image = MainService.GetImage(Path.Combine(Application.StartupPath, "welcome.png"));
            }

            //查找可以播放的视频
            string[] files = Directory.GetFiles(SuperObject.ReadmeDir);
            foreach (string sss in files)
            {
                foreach (string exts in VideoAndAudioPlayerUI.SupportedExtName)
                {
                    if (sss.EndsWith(exts))
                    {
                        videoFiles.Add(sss);
                        break;
                    }
                }
            }

            //检查当前对话状态
            if (AIUIStatus == "talk")
            {
                //对话状态
                Lock();
            }
            else
            {
                //监听状态
                UnLock();
            }
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            vpcPlayer.StopPlayer();
        }

        /// <summary>
        /// 继续循环播放视频
        /// </summary>
        public void UnLock()
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    pbFace.Visible = false;
                    vpcPlayer.Visible = true;

                    if (videoFiles.Count >= 1)
                    {
                        vpcPlayer.SetMediaUrl(videoFiles[0]);
                    }
                }));
            }
        }

        /// <summary>
        /// 锁定视频播放,只显示welcome.png
        /// </summary>
        public void Lock()
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                    {
                        pbFace.Visible = true;
                        vpcPlayer.Visible = false;
                        vpcPlayer.StopPlayer();
                    }));
            }
        }
    }
}