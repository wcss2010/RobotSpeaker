using AIUISerials;
using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSpeaker
{
    public class XFOnlineMessageDataAdapter : IRobotMessageDataAdapter
    {
        byte[] _headerBytes = new byte[] { 0xA5, 0x01 };
        bool enabledFindNext = true;
        int headerIndex = 0;

        public override byte[] Resolve()
        {
            try
            {
                List<byte> _recievedData = this.SerialPortInputObject.BufferStream;

                //尝试查找包头
                if (enabledFindNext)
                {
                    headerIndex = SearchInBuffer(_headerBytes);
                    if (headerIndex >= 0)
                    {
                        //有效数据
                        enabledFindNext = false;
                    }
                    else
                    {
                        //无效数据直接清空
                        lock (SerialPortInput.lockObject)
                        {
                            _recievedData.Clear();
                        }
                    }
                }

                if (headerIndex + 8 >= _recievedData.Count)
                {
                    Thread.Sleep(10);
                }

                int length = BitConverter.ToInt16(new byte[] { _recievedData[headerIndex + 3], _recievedData[headerIndex + 4] }, 0);
                if (headerIndex + length + 8 > _recievedData.Count)
                {
                    Thread.Sleep(10);
                }

                if (_recievedData.Count >= length + 8)
                {
                    byte[] msg = _recievedData.GetRange(headerIndex, length + 8).ToArray();

                    //解析SeqID并且回复确认
                    if (msg[msg.Length - 1] == Utils.CalcCheckCode(new List<byte>(msg)))
                    {
                        //设置SeqId
                        int id = BitConverter.ToInt16(new byte[] { msg[5], msg[6] }, 0);
                        MainService.AiuiOnlineService.AiuiConnection.packetBuilder.setSeqId(id);

                        //自动回复
                        MainService.AiuiOnlineService.AiuiConnection.SendConfirmMessage();
                    }

                    //取数据
                    byte[] bytes = new byte[0];
                    if (msg[2] == 0x04)
                    {
                        bytes = _recievedData.GetRange(headerIndex + 7, length).ToArray();
                    }

                    //删除解析过的数据
                    lock (SerialPortInput.lockObject)
                    {
                        _recievedData.RemoveRange(0, headerIndex + length + 8);
                    }

                    enabledFindNext = true;
                    headerIndex = 0;

                    return bytes;
                }
                else
                {
                    return new byte[0];
                }
            }
            catch (Exception ex)
            {
                headerIndex = 0;
                return new byte[0];
            }
        }

        public int SerailDataLength { get; set; }
    }
}