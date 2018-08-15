using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp;

namespace AIUISerials
{
    public class AIUIOffineConnection
    {
        /// <summary>
        /// 直接连接串口
        /// </summary>
        private SerialPort _serial;

        /// <summary>
        /// 数据集
        /// </summary>
        protected List<byte> _recievedData;

        /// <summary>
        /// 负责接收串口消息的线程
        /// </summary>
        private Thread _threadResponse;

        /// <summary>
        /// 串口接收到的原始日志，默认0不写 1写
        /// </summary>
        private static string originalLog = "0";

        /// <summary>
        /// 即将发送的数据日志，默认0不写 1写
        /// </summary>
        private string _fulfilLog = "0";
        
        private WebSocket _webSocket;
        /// <summary>
        /// WebSocket
        /// </summary>
        public WebSocket WebSocket
        {
            get { return _webSocket; }
        }

        /// <summary>
        /// WebSocket服务端地址
        /// </summary>
        private string _socketUrl = string.Empty;

        /// <summary>
        /// 是否需要开启webSocket 0默认是连接 1不需要连接
        /// </summary>
        private string _socketOpen = "0";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="parity"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBits"></param>
        public AIUIOffineConnection(string portName, int baudRate = 921600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            _recievedData = new List<byte>();
            try
            {
                _serial = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                _serial.DataReceived += new SerialDataReceivedEventHandler(Serial_DataReceived);
                _serial.Open();

                if (_threadResponse == null)
                {
                    _threadResponse = new Thread(new ThreadStart(OnRevieved));
                    _threadResponse.IsBackground = true;
                    _threadResponse.Start();
                }

                // 开启一个WebSocket
                _webSocket = new WebSocket(_socketUrl);
                _webSocket.WaitTime = TimeSpan.FromMilliseconds(1);
                _webSocket.OnMessage += new EventHandler<MessageEventArgs>(SocketMessage);
                _webSocket.Connect();
            }
            catch (Exception ex)
            {
                Writelog("ErrorLog", string.Format("Start_Click:{0}", ex.Message));
            }
        }

        #region 2.1、读取串口数据
        /// <summary>
        /// 直接读取串口数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] data = new byte[_serial.BytesToRead];
                _serial.Read(data, 0, data.Length);

                object lockHelper = new object();
                lock (lockHelper)
                {
                    _recievedData.AddRange(data);

                    if (!string.IsNullOrEmpty(originalLog) && originalLog == "1")
                    {
                        string w = string.Empty;
                        foreach (byte r in data)
                        {
                            w += r.ToString("X2") + " ";
                        }

                        Writelog("OriginalLog", w);
                    }
                }
            }
            catch (System.Exception ex)
            {
                // 记录日志：读取串口数据出错
                Writelog("ErrorLog", string.Format("Serial_DataReceived:{0}", ex.Message, 1));
            }
        }
        #endregion

        #region 2.2、识别结果判断帧头帧尾，并发送

        /// <summary>
        /// 接收线程启动
        /// </summary>
        protected void OnRevieved()
        {
            // 从接收数据缓冲区取出数据并组装成Response对象
            object lockHelper = new object();
            bool resAssembling = false;
            int headerIndex = 0;

            while (true)
            {
                try
                {
                    if (_recievedData.Count > 0)
                    {
                        if (!resAssembling)
                        {
                            while (headerIndex + 3 < _recievedData.Count && !(_recievedData[headerIndex] == 0xFD && _recievedData[headerIndex + 1] == 0x00 && _recievedData[headerIndex + 2] == 0x80 && _recievedData[headerIndex + 3] == 0x00))
                            {
                                headerIndex++;
                            }
                            lock (lockHelper)
                            {
                                if (headerIndex >= _recievedData.Count)
                                {
                                    //headerIndex = 0;
                                    _recievedData.Clear();
                                    continue;
                                }
                            }
                            resAssembling = true;
                        }

                        if (headerIndex + 2 >= _recievedData.Count)
                        {
                            Thread.Sleep(10);
                            continue;
                        }

                        // 帧长度=数据区长度+1
                        int length = 264;
                        if (headerIndex + length > _recievedData.Count)
                        {
                            Thread.Sleep(10);
                            continue;
                        }

                        Response response = new Response();
                        response.DataArea = new Response.ResData();
                        // 固定长度位
                        response.DataArea.Length = 264;
                        response.DataArea.Content = _recievedData.GetRange(headerIndex, response.DataArea.Length);

                        if (response != null)
                        {
                            string w = string.Empty;

                            foreach (byte r in response.DataArea.Content.ToArray())
                            {
                                w += r.ToString("X2") + " ";
                            }

                            if (!string.IsNullOrEmpty(_fulfilLog) && _fulfilLog == "1")
                            {
                                Writelog("FulfilLog", w);
                            }
                            if (_socketOpen == "0")
                            {
                                // 发送WebSocket
                                _webSocket.Send(w);
                            }
                        }

                        _recievedData.RemoveRange(0, headerIndex + length);
                        resAssembling = false;
                        headerIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    headerIndex = 0;
                    // 记录日志：处理状态帧出错
                    Writelog("ErrorLog", string.Format("OnRevieved:{0}", ex.Message));
                }
            }
        }

        #endregion

        #region 2.4 WebSocket接收消息
        /// <summary>
        /// WebSocket接收消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SocketMessage(object sender, MessageEventArgs e)
        {
            Writelog("SocketMessage", e.Data, 1);
        }
        #endregion

        #region 10、简单写日志
        /// <summary>
        /// 简单写日志
        /// </summary>
        /// <param name="fileName">日志文件名</param>
        /// <param name="msg">日志内容</param>
        public static void Writelog(string fileName, string msg, int lineMore = 0)
        {
            StreamWriter stream;
            //写入日志内容
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd"));
            //检查上传的物理路径是否存在，不存在则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            stream = new StreamWriter(string.Format("{0}\\{1}.txt", path, fileName), true, Encoding.Default);
            stream.Write(msg);
            if (lineMore > 0)
            {
                stream.Write("\r\n");
            }

            stream.Flush();
            stream.Close();
        }
        #endregion
        
        /// <summary>
        /// 结束函数
        /// </summary>
        public void Dispose()
        {
            _threadResponse.Abort();
            _webSocket.Close();
            _serial.Close();

        }
    }

    public class Response
    {
        /// <summary>
        /// 数据区
        /// </summary>
        public ResData DataArea { get; set; }

        /// <summary>
        /// 状态帧数据区
        /// </summary>
        public class ResData
        {
            /// <summary>
            /// 长度
            /// </summary>
            public int Length { get; set; }
            /// <summary>
            /// 状态码
            /// </summary>
            public byte StatusCode { get; set; }
            /// <summary>
            /// 数据内容
            /// </summary>
            public List<byte> Content { get; set; }
        }
    }
}