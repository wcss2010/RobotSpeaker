using RobotSpeaker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RobotSpeaker
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //载入配置
            SuperObject.LoadConfig();

            //创建目录
            try
            {
                System.IO.Directory.CreateDirectory(SuperObject.ReadmeDir);
            }
            catch (Exception ex) { }

            try
            {
                System.IO.Directory.CreateDirectory(SuperObject.CameraPhotoDir);
            }
            catch (Exception ex) { }

            try
            {
                System.IO.Directory.CreateDirectory(SuperObject.CameraVideoDir);
            }
            catch (Exception ex) { }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainUI());
        }
    }
}