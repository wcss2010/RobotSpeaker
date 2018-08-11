using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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
        public RobotConfig()
        {
            Params = new SerializableDictionary<string, object>();
        }

        /// <summary>
        /// 参数字典
        /// </summary>
        public SerializableDictionary<string, object> Params { get; set; }

        /// <summary>
        /// 当进行语音对话时是否允许关闭VideoPlayer
        /// </summary>
        public bool EnabledCloseVideoPlayerWithVoice { get; set; }

        /// <summary>
        /// 是否允许使用在线语音模式
        /// </summary>
        public bool EnabledOnlineVoice { get; set; }

        /// <summary>
        /// 讯飞语音端口(在线)
        /// </summary>
        public string OnlineVoicePort { get; set; }

        /// <summary>
        /// 讯飞语音端口(离线)
        /// </summary>
        public string OfflineVoicePort { get; set; }

        /// <summary>
        /// 运动控制器端口
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

        private string _voiceWelcomeText = "您好，我有什么能够帮你？";
        /// <summary>
        /// 语音对话欢迎词
        /// </summary>
        public string VoiceWelcomeText
        {
            get { return _voiceWelcomeText; }
            set { _voiceWelcomeText = value; }
        }

        private int _imageListPlayerSleepSeconds = 6;
        /// <summary>
        /// 图片展示每张图的停留时间(秒)
        /// </summary>
        public int ImageListPlayerSleepSeconds
        {
            get { return _imageListPlayerSleepSeconds; }
            set { _imageListPlayerSleepSeconds = value; }
        }

        private string _OfflineVoiceWebSocketUrl = string.Empty;
        /// <summary>
        /// 离线语音的WebSocketUrl
        /// </summary>
        public string OfflineVoiceWebSocketUrl
        {
            get { return _OfflineVoiceWebSocketUrl; }
            set { _OfflineVoiceWebSocketUrl = value; }
        }

        /// <summary>
        /// 从字典中获得一个值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public E GetValue<E>(string key)
        {
            E result = default(E);

            //检查Params是否为空
            if (Params == null)
            {
                Params = new SerializableDictionary<string, object>();
            }

            //获得数值
            if (Params.ContainsKey(key))
            {
                result = (E)Params[key];
            }

            return result;
        }

        /// <summary>
        /// 向字典中保存一个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue<E>(string key, E value)
        {
            //检查是否Params为空
            if (Params == null)
            {
                Params = new SerializableDictionary<string, object>();
            }

            //设置数值
            Params[key] = value;
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

    /// <summary>
    /// 支持XML序列化的泛型 Dictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [XmlRoot("SerializableDictionary")]
    public class SerializableDictionary<TKey, TValue>
        : Dictionary<TKey, TValue>, IXmlSerializable
    {

        #region 构造函数
        public SerializableDictionary()
            : base()
        {
        }
        public SerializableDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
        }

        public SerializableDictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
        }

        public SerializableDictionary(int capacity)
            : base(capacity)
        {
        }
        public SerializableDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        {
        }
        protected SerializableDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        #endregion
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        /// <summary>
        /// 从对象的 XML 表示形式生成该对象
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                this.Add(key, value);
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        /**/
        /// <summary>
        /// 将对象转换为其 XML 表示形式
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            foreach (TKey key in this.Keys)
            {
                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                TValue value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
        #endregion
    }
}