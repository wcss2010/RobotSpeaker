using RobotSpeaker.Forms.CameraAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            btnGetPic.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\pic1.png"));
            btnGetPic.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\pic2.png"));

            btnRecord.NoFocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\video1.png"));
            btnRecord.FocusImage = DataService.GetImage(Path.Combine(Application.StartupPath, @"Images\video2.png"));

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
            if (btnRecord.Enabled)
            {
                try
                {
                    videoObj.StopKinescope();
                }
                catch (Exception ex) { }
            }

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
            try
            {
                videoObj.StopKinescope();
            }
            catch (Exception ex)
            { }

            btnStopRecord.Visible = false;

            btnRecord.Enabled = true;
            btnRecord.EnabledMouseDownAndMouseUp = true;
            btnRecord.IsPressed = false;
            btnRecord.BottomText = "开始录像";
        }

        private void btnGetPic_Click(object sender, EventArgs e)
        {
            try
            {
                videoObj.grabImage(Path.Combine(SuperObject.CameraPhotoDir, DateTime.Now.Ticks + ".bmp"));
                MessageBox.Show("操作完成！");
            }
            catch (Exception ex) { }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                videoObj.StarKinescope(Path.Combine(SuperObject.CameraPhotoDir, DateTime.Now.Ticks + ".avi"));
                btnStopRecord.Visible = true;

                btnRecord.Enabled = false;
                btnRecord.EnabledMouseDownAndMouseUp = false;
                btnRecord.IsPressed = true;
                btnRecord.BottomText = "正在录像";
            }
            catch (Exception ex) { }
        }

        private void plContent_Paint(object sender, PaintEventArgs e)
        {
            //画图像框上面的白线框
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(pbImage.Left - 5, pbImage.Top - 5), new Point(pbImage.Right + 5, pbImage.Top - 5));
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(pbImage.Left - 5, pbImage.Bottom + 5), new Point(pbImage.Right + 5, pbImage.Bottom + 5));

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(pbImage.Left - 5, pbImage.Top - 5), new Point(pbImage.Left - 5, pbImage.Top + 50));
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(pbImage.Right + 5, pbImage.Top - 5), new Point(pbImage.Right + 5, pbImage.Top + 50));

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(pbImage.Left - 5, pbImage.Bottom - 50), new Point(pbImage.Left - 5, pbImage.Bottom + 5));
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(pbImage.Right + 5, pbImage.Bottom - 50), new Point(pbImage.Right + 5, pbImage.Bottom + 5));
        }
    }
}