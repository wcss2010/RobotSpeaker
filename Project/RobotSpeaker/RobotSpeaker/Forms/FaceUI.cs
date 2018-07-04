using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using RobotSpeaker.Forms.CameraAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace RobotSpeaker.Forms
{
    public partial class FaceUI : PageUIBase
    {
        private string videoFileFullPath = string.Empty; //视频文件全路径
        private string imageFileFullPath = string.Empty; //图像文件全路径
        private string videoFileName = string.Empty; //视频文件名
        private string drawDate = string.Empty;
        private bool stopREC = true;
        private bool createNewFile = true;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private VideoFileReader _reader;
        private VideoFileWriter _writer;
        int frameRate = 25; //默认帧率
        private VideoFileWriter videoWriter = null;

        [DllImport("gdi32")]
        static extern int DeleteObject(IntPtr o);

        public FaceUI()
        {
            InitializeComponent();

            // 枚举所有视频输入设备
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                Close();
            }
        }

        /// <summary>
        /// 打开摄像头
        /// </summary>
        private void CameraOpen()
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.DesiredFrameSize = new System.Drawing.Size(vsVideoSource.Width, vsVideoSource.Height);
            videoSource.DesiredFrameRate = 1;

            vsVideoSource.VideoSource = videoSource;
            vsVideoSource.Start();
        }

        /// <summary>
        /// 关闭摄像头
        /// </summary>
        private void CameraClose()
        {
            vsVideoSource.SignalToStop();
            vsVideoSource.WaitForStop();
        }

        /// <summary>
        /// 拍照功能
        /// </summary>
        private void GetPic(string picName)
        {
            try
            {
                if (vsVideoSource.IsRunning)
                {
                    IntPtr ip = vsVideoSource.GetCurrentVideoFrame().GetHbitmap();
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    ip,
                                    IntPtr.Zero,
                                     System.Windows.Int32Rect.Empty,
                                    BitmapSizeOptions.FromEmptyOptions());
                    DeleteObject(ip);
                    PngBitmapEncoder pE = new PngBitmapEncoder();

                    pE.Frames.Add(BitmapFrame.Create(bitmapSource));

                    if (File.Exists(picName))
                    {
                        File.Delete(picName);
                    }
                    using (Stream stream = File.Create(picName))
                    {
                        pE.Save(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("摄像头异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 开始录像
        /// </summary>
        private void RecordStart()
        {
            stopREC = false;
        }

        /// <summary>
        /// 停止录像
        /// </summary>
        private void RecordStop()
        {
            stopREC = true;
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
            CameraOpen();
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
                    RecordStop();
                }
                catch (Exception ex) { }
            }

            //关闭摄像头
            try
            {
                CameraClose();
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
                RecordStop();
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
                GetPic(Path.Combine(SuperObject.CameraPhotoDir, DateTime.Now.Ticks + ".jpg"));
                MessageBox.Show("操作完成！");
            }
            catch (Exception ex) { }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                RecordStart();

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
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(vsVideoSource.Left - 5, vsVideoSource.Top - 5), new Point(vsVideoSource.Right + 5, vsVideoSource.Top - 5));
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(vsVideoSource.Left - 5, vsVideoSource.Bottom + 5), new Point(vsVideoSource.Right + 5, vsVideoSource.Bottom + 5));

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(vsVideoSource.Left - 5, vsVideoSource.Top - 5), new Point(vsVideoSource.Left - 5, vsVideoSource.Top + 50));
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(vsVideoSource.Right + 5, vsVideoSource.Top - 5), new Point(vsVideoSource.Right + 5, vsVideoSource.Top + 50));

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(vsVideoSource.Left - 5, vsVideoSource.Bottom - 50), new Point(vsVideoSource.Left - 5, vsVideoSource.Bottom + 5));
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray)), new Point(vsVideoSource.Right + 5, vsVideoSource.Bottom - 50), new Point(vsVideoSource.Right + 5, vsVideoSource.Bottom + 5));
        }

        private void vsVideoSource_NewFrame(object sender, ref Bitmap image)
        {
            //录像
            Graphics g = Graphics.FromImage(image);
            SolidBrush drawBrush = new SolidBrush(Color.Yellow);

            Font drawFont = new Font("Arial", 6, System.Drawing.FontStyle.Bold, GraphicsUnit.Millimeter);
            int xPos = image.Width - (image.Width - 15);
            int yPos = 10;
            //写到屏幕上的时间
            drawDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            g.DrawString(drawDate, drawFont, drawBrush, xPos, yPos);

            if (stopREC)
            {
                stopREC = true;
                createNewFile = true;  //这里要设置为true表示要创建新文件
                if (videoWriter != null)
                {
                    videoWriter.Close();
                }
            }
            else
            {
                //开始录像
                if (createNewFile)
                {
                    videoFileName = DateTime.Now.ToString("yyyyMMddHH") + ".avi";
                    videoFileFullPath = Path.Combine(SuperObject.CameraVideoDir, videoFileName);
                    createNewFile = false;
                    if (videoWriter != null)
                    {
                        videoWriter.Close();
                        videoWriter.Dispose();
                    }
                    videoWriter = new VideoFileWriter();
                    //这里必须是全路径，否则会默认保存到程序运行根据录下了
                    videoWriter.Open(videoFileFullPath, image.Width, image.Height, frameRate, VideoCodec.MPEG4);
                    videoWriter.WriteVideoFrame(image);
                }
                else
                {
                    videoWriter.WriteVideoFrame(image);
                }
            }
        }
    }
}