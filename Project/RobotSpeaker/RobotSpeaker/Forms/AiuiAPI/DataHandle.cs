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
    public class DataHandle
    {
        SerialPortExForAIUI comm;
        AIUI aiui;
        int serailDataLength = 0;
        Packet packet = new Packet();

        List<byte> dataList = new List<byte>();

        public DataHandle(SerialPortExForAIUI comm, AIUI aiui)
        {
            this.comm = comm;
            this.aiui = aiui;
        }

        public void sendShake() {
            SendCardToOut(packet.buildShakePacket());
        }

        public void clearDataList() {
            dataList.Clear();
            serailDataLength = 0;
        }

        public void handleRecieveData(byte[] data) {
            for (int i = 0; i < data.Length; i++) {
                dataList.Add(data[i]);
                if (dataList.Count == 5)
                {
                    if (dataList[0] == 0xa5 && dataList[1] == 0x01)
                    {
                        serailDataLength = ((dataList[4] & 0xff) << 8) + (dataList[3] & 0xff);
                    }
                    else {
                        dataList.RemoveAt(0);
                    }
                    
                }

                if (serailDataLength != 0 && dataList.Count != 0 && dataList.Count == 8 + serailDataLength)
                {
                    if (dataList[0] == 0xa5 && dataList[1] == 0x01)
                    {
                        if (dataList[dataList.Count - 1] == Utils.CalcCheckCode(dataList))
                        {
                            int id = ((dataList[6] & 0xff) << 8) + dataList[5];
                            packet.setSeqId(id);
                            if (aiui.getIsConsoleOn())
                            {
                                LogRecieve(dataList);
                            }

                            if (aiui.getAutoReply())
                            {
                                SendConfirmMessage();
                            }
                            
                            dealMsg(dataList, serailDataLength);
                        }
                    }
                    clearDataList();
                }
            }
            
        }

        private void dealMsg(List<byte> list, int contentLen) {
            if (list[2] == 0x04)
            {
                byte[] data = new byte[contentLen];
                for (int j = 0; j < contentLen; j++)
                {
                    data[j] = list[j + 7];
                }

                string result = Utils.Decompress(data);
                aiui.SetAIUIMsg(result);
            }
        }

        private void SendConfirmMessage() {
            SendCardToOut(packet.buildConfirmPacket());
        }

        public void SendTTSMessage(string text) {
            SendCardToOut(packet.buildTtsPacket(text));
        }

        public void ConfigWifiMessage(string config) {
            SendCardToOut(packet.buildWifiCfgPacket(config));
        }

        public void SendAIUIConfigMessage(string config)
        {
            SendCardToOut(packet.buildAIUIConfigPacket(config));
        }

        public void SendLauchVoiceMessage(Boolean isOn) {
            SendCardToOut(packet.buildVoiceControlPacket(isOn));
        }

        public void SendSmartConfigMessage(Boolean isOn) {
            SendCardToOut(packet.buildSmartConfigPacket(isOn));
        }

        public void SendWakeUpMessage(Boolean isReset)
        {
            SendCardToOut(packet.buildResetWakePacket(isReset));
        }

        public void SendCustomMessage(byte[] data) {
            SendCardToOut(packet.buildCustomDataPacket(data));
        }
        
        public void SendCardToOut(List<byte> send)
        {
            if (comm.IsOpen)
            {
                comm.WritePort(send.ToArray(), 0, send.Count);
                if (aiui.getIsConsoleOn()) {
                    LogSend(send);
                }
            }    
        }

        public void SendCmd(string sendCmd) {
            SendCardToOut(packet.buildCmdPacket(sendCmd));
        }

        private void LogSend(List<byte> send) {
            string logData = "";
            for (int index = 0; index < send.Count; index++)
            {
                if (index == 0)
                {
                    logData += "Send :[ ";
                }
                if (index == send.Count - 1)
                {
                    logData += Convert.ToString(send[index]) +  "]\n\n";
                }
                else
                {
                    logData += Convert.ToString(send[index]) + ", ";
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(logData);
        
        }

        private void LogRecieve(List<byte> recive)
        {
            string logData = "";
            for (int index = 0; index < recive.Count; index++)
            {
                if (index == 0)
                {
                    logData += "Recived :[ ";
                }
                if (index == recive.Count - 1)
                {
                    logData += Convert.ToString(recive[index]) + "]\n\n";
                }
                else
                {
                    logData += Convert.ToString(recive[index]) + ", ";
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(logData);
        }
    }
}
