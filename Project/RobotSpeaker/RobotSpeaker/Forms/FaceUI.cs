using RobotSpeaker.Forms.CameraAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker.Forms
{
    public partial class FaceUI : PageUIBase
    {
        Video videoObj = null;

        public FaceUI()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //设置居中
            plContent.Top = (Screen.PrimaryScreen.Bounds.Height - plContent.Height) / 2;
            plContent.Left = (Screen.PrimaryScreen.Bounds.Width - plContent.Width) / 2;

            btnGetPic.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\pic1.png"));
            btnGetPic.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\pic2.png"));

            btnRecord.NoFocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\video1.png"));
            btnRecord.FocusImage = Image.FromFile(Path.Combine(Application.StartupPath, @"Images\video2.png"));

            //启动摄像头
            videoObj = new Video(pbImage.Handle, pbImage.Width, pbImage.Height);
            videoObj.StartWebCam();
        }

        protected override void OnClickBackButton(EventArgs e)
        {
            base.OnClickBackButton(e);

            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //停止录像
            try
            {
                videoObj.StopKinescope();
            }
            catch (Exception ex) { }

            //关闭摄像头
            try
            {
                videoObj.CloseWebcam(0);
            }
            catch (Exception ex) { }
        }

        private void btnPauseRecord_Click(object sender, EventArgs e)
        {

        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            videoObj.StopKinescope();
            btnStopRecord.Visible = false;
            btnRecord.Enabled = true;
        }

        private void btnGetPic_Click(object sender, EventArgs e)
        {
            videoObj.grabImage(Path.Combine(SuperObject.CameraPhotoDir, DateTime.Now.Ticks + ".bmp"));
            MessageBox.Show("操作完成！");
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {            
            videoObj.StarKinescope(Path.Combine(SuperObject.CameraPhotoDir, DateTime.Now.Ticks + ".avi"));
            btnStopRecord.Visible = true;
            btnRecord.Enabled = false;
        }
    }
}