using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using SerialPortLib;

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

        private int serailDataLength = 0;
        private PacketBuilder packetBuilder = new PacketBuilder();
        private List<byte> dataList = new List<byte>();

        private bool _enabledAutoReply = true;
        /// <summary>
        /// 是否支持自动回复
        /// </summary>
        public bool EnabledAutoReply
        {
            get { return _enabledAutoReply; }
            set { _enabledAutoReply = value; }
        }

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
            _serialPort.SetPort(comPort, 115200, System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None, 100, -1);
            _serialPort.MessageReceived += _serialPort_MessageReceived;
            
        }

        void _serialPort_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            byte[] readBuffer = args.Data;

            for (int i = 0; i < readBuffer.Length; i++)
            {
                dataList.Add(readBuffer[i]);
                if (dataList.Count == 5)
                {
                    if (dataList[0] == 0xa5 && dataList[1] == 0x01)
                    {
                        serailDataLength = ((dataList[4] & 0xff) << 8) + (dataList[3] & 0xff);
                    }
                    else
                    {
                        dataList.RemoveAt(0);
                    }
                }

                if (serailDataLength != 0 && dataList.Count != 0 && dataList.Count == 8 + serailDataLength)
                {
                    if (dataList[0] == 0xa5 && dataList[1] == 0x01)
                    {
                        if (dataList[dataList.Count - 1] == Utils.CalcCheckCode(dataList))
                        {
                            //取ID
                            int id = ((dataList[6] & 0xff) << 8) + dataList[5];

                            //设置ID
                            packetBuilder.setSeqId(id);

                            //自动回复
                            if (EnabledAutoReply)
                            {
                                SendConfirmMessage();
                            }

                            //处理消息
                            dealMsg(dataList, serailDataLength);
                        }
                    }

                    //清理缓冲区
                    ClearDataList();
                }
            }
        }

        public void ClearDataList()
        {
            dataList.Clear();
            serailDataLength = 0;
        }
        
        /// <summary>
        /// 投递Json消息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="contentLen"></param>
        private void dealMsg(List<byte> list, int contentLen) {
            if (list[2] == 0x04)
            {
                byte[] data = new byte[contentLen];
                for (int j = 0; j < contentLen; j++)
                {
                    data[j] = list[j + 7];
                }

                //投递消息事件
                OnAIUIConnectionReceivedEvent(Utils.Decompress(data));
            }
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
    }
}