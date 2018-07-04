using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RobotSpeaker
{
    public class SuperObject
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string ConfigPath = Path.Combine(Application.StartupPath, "config.xml");

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

        /// <summary>
        /// 配置项
        /// </summary>
        public static RobotConfig Config { get; set; }

        /// <summary>
        /// 载入配置
        /// </summary>
        public static void LoadConfig()
        {
            if (File.Exists(ConfigPath))
            {
                Config = (RobotConfig)XmlUtil.Deserialize(typeof(RobotConfig), File.ReadAllText(ConfigPath));
            }
            else
            {
                Config = new RobotConfig();
                SaveConfig();
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void SaveConfig()
        {
            if (Config == null)
            {
                Config = new RobotConfig();
            }
            string xml = XmlUtil.Serializer(typeof(RobotConfig), Config);
            File.WriteAllText(ConfigPath, xml);
        }
    }

    /// <summary>
    /// 配置
    /// </summary>
    public class RobotConfig
    {
        /// <summary>
        /// 语音端口
        /// </summary>
        public string VoicePort { get; set; }

        /// <summary>
        /// 运动端口
        /// </summary>
        public string GoPort { get; set; }

        /// <summary>
        /// 运动规划程序路径
        /// </summary>
        public string GoAppPath { get; set; }

        /// <summary>
        /// 当前运动类型
        /// </summary>
        public GoType CurrentGoType { get; set; }

        private string _webSiteUrl = "www.baidu.com";
        /// <summary>
        /// 默认首页
        /// </summary>
        public string WebSiteUrl
        {
            get { return _webSiteUrl; }
            set { _webSiteUrl = value; }
        }

        private string _managerPassword = "123456";
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string ManagerPassword
        {
            get { return _managerPassword; }
            set { _managerPassword = value; }
        }

        
    }

    /// <summary>
    /// 运行类型
    /// </summary>
    public enum GoType
    {
       Normal,Joy,Free
    }

    /// <summary>
/// Xml序列化与反序列化
/// </summary>
    public class XmlUtil
    {
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }
        #endregion
    }
}