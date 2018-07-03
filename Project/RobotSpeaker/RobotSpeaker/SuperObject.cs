using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotSpeaker
{
    public class SuperObject
    {
        /// <summary>
        /// 自我介绍
        /// </summary>
        public static string ReadmeDir = Path.Combine(Application.StartupPath, "readme");

        /// <summary>
        /// 摄像头
        /// </summary>
        public static string CameraDir = Path.Combine(Application.StartupPath, "camera");

        /// <summary>
        /// 照片
        /// </summary>
        public static string CameraPhotoDir = Path.Combine(CameraDir, "photo");

        /// <summary>
        /// 视频
        /// </summary>
        public static string CameraVideoDir = Path.Combine(CameraDir, "video");
    }
}