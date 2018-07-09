using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

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
        private SerialPortExForAIUI _serialPort = null;
        /// <summary>
        /// 串口连接
        /// </summary>
        public SerialPortExForAIUI SerialPort
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

        public AIUIConnection(string port)
        {
            _serialPort = new SerialPortExForAIUI(port);
            _serialPort.DataReceived += comm_DataReceived;
        }

        void comm_DataReceived(byte[] readBuffer)
        {
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

                            dealMsg(dataList, serailDataLength);
                        }
                    }

                    //清空缓冲区
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
            SerialPort.WritePort(packetBuilder.buildShakePacket().ToArray());
        }

        public void SendConfirmMessage()
        {
            SerialPort.WritePort(packetBuilder.buildConfirmPacket().ToArray());
        }

        public void SendTTSMessage(string text)
        {
            SerialPort.WritePort(packetBuilder.buildTtsPacket(text).ToArray());
        }

        public void ConfigWifiMessage(string config)
        {
            SerialPort.WritePort(packetBuilder.buildWifiCfgPacket(config).ToArray());
        }

        public void SendAIUIConfigMessage(string config)
        {
            SerialPort.WritePort(packetBuilder.buildAIUIConfigPacket(config).ToArray());
        }

        public void SendLauchVoiceMessage(Boolean isOn)
        {
            SerialPort.WritePort(packetBuilder.buildVoiceControlPacket(isOn).ToArray());
        }

        public void SendSmartConfigMessage(Boolean isOn)
        {
            SerialPort.WritePort(packetBuilder.buildSmartConfigPacket(isOn).ToArray());
        }

        public void SendWakeUpMessage(Boolean isReset)
        {
            SerialPort.WritePort(packetBuilder.buildResetWakePacket(isReset).ToArray());
        }

        public void SendCustomMessage(byte[] data)
        {
            SerialPort.WritePort(packetBuilder.buildCustomDataPacket(data).ToArray());
        }

        public void SendCmd(string sendCmd)
        {
            SerialPort.WritePort(packetBuilder.buildCmdPacket(sendCmd).ToArray());
        }
    }
}