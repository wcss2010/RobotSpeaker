using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using SerialPortLib;
using RobotSpeaker;

namespace AIUISerials
{
    public delegate void AIUIConnectionReceivedDelegate(object sender, AIUIConnectionReceivedEventArgs args);

    public class AIUIConnectionReceivedEventArgs : EventArgs
    {
        public string Json { get; set; }

        public AIUIConnectionReceivedEventArgs(string str)
        {
            Json = str;
        }
    }

    public class AIUIConnection
    {
        private SerialPortInput _serialPort = null;
        /// <summary>
        /// 串口连接
        /// </summary>
        public SerialPortInput SerialPort
        {
            get { return _serialPort; }
        }
        public PacketBuilder packetBuilder = new PacketBuilder();

        public event AIUIConnectionReceivedDelegate AIUIConnectionReceivedEvent;

        protected void OnAIUIConnectionReceivedEvent(string json)
        {
            if (AIUIConnectionReceivedEvent != null)
            {
                AIUIConnectionReceivedEvent(this, new AIUIConnectionReceivedEventArgs(json));
            }
        }

        public AIUIConnection(string comPort)
        {
            _serialPort = new SerialPortInput();
            _serialPort.MessageDataAdapterObject = new XFOnlineMessageDataAdapter();
            _serialPort.SetPort(comPort, 115200, System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None, -1, -1);
            _serialPort.MessageReceived += _serialPort_MessageReceived;
            
        }

        void _serialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            //投递消息事件
            OnAIUIConnectionReceivedEvent(Utils.Decompress(args.Data));
        }

        public void SendShake()
        {
            SerialPort.SendMessage(packetBuilder.buildShakePacket().ToArray());
        }

        public void SendConfirmMessage()
        {
            SerialPort.SendMessage(packetBuilder.buildConfirmPacket().ToArray());
        }

        public void SendTTSMessage(string text)
        {
            SerialPort.SendMessage(packetBuilder.buildTtsPacket(text).ToArray());
        }

        public void ConfigWifiMessage(string config)
        {
            SerialPort.SendMessage(packetBuilder.buildWifiCfgPacket(config).ToArray());
        }

        public void SendAIUIConfigMessage(string config)
        {
            SerialPort.SendMessage(packetBuilder.buildAIUIConfigPacket(config).ToArray());
        }

        public void SendLauchVoiceMessage(Boolean isOn)
        {
            SerialPort.SendMessage(packetBuilder.buildVoiceControlPacket(isOn).ToArray());
        }

        public void SendSmartConfigMessage(Boolean isOn)
        {
            SerialPort.SendMessage(packetBuilder.buildSmartConfigPacket(isOn).ToArray());
        }

        public void SendWakeUpMessage(Boolean isReset)
        {
            SerialPort.SendMessage(packetBuilder.buildResetWakePacket(isReset).ToArray());
        }

        public void SendCustomMessage(byte[] data)
        {
            SerialPort.SendMessage(packetBuilder.buildCustomDataPacket(data).ToArray());
        }

        public void SendCmd(string sendCmd)
        {
            SerialPort.SendMessage(packetBuilder.buildCmdPacket(sendCmd).ToArray());
        }

        /// <summary>
        /// 报告指定的 System.Byte[] 在此实例中的第一个匹配项的索引。
        /// </summary>
        /// <param name="srcBytes">被执行查找的 System.Byte[]。</param>
        /// <param name="searchBytes">要查找的 System.Byte[]。</param>
        /// <returns>如果找到该字节数组，则为 searchBytes 的索引位置；如果未找到该字节数组，则为 -1。如果 searchBytes 为 null 或者长度为0，则返回值为 -1。</returns>
        public int IndexOf(byte[] srcBytes, byte[] searchBytes)
        {
            if (srcBytes == null) { return -1; }
            if (searchBytes == null) { return -1; }
            if (srcBytes.Length == 0) { return -1; }
            if (searchBytes.Length == 0) { return -1; }
            if (srcBytes.Length < searchBytes.Length) { return -1; }
            for (int i = 0; i < srcBytes.Length - searchBytes.Length; i++)
            {
                if (srcBytes[i] == searchBytes[0])
                {
                    if (searchBytes.Length == 1) { return i; }
                    bool flag = true;
                    for (int j = 1; j < searchBytes.Length; j++)
                    {
                        if (srcBytes[i + j] != searchBytes[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) { return i; }
                }
            }
            return -1;
        }
    }
}