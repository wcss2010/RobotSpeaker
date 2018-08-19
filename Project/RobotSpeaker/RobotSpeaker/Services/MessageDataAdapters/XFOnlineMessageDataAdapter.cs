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
        int headerIndex = 0;

        public override byte[] Resolve()
        {
            List<byte> _recievedData = this.SerialPortInputObject.BufferStream;

            try
            {
                //尝试查找包头
                headerIndex = SearchInBuffer(_headerBytes);

                if (headerIndex + 8 >= _recievedData.Count)
                {
                    Thread.Sleep(10);
                }

                int length = BitConverter.ToInt16(new byte[] { _recievedData[headerIndex + 3], _recievedData[headerIndex + 4] }, 0);
                if (length >= 0)
                {
                    if (headerIndex + length + 8 > _recievedData.Count)
                    {
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    //无效数据
                    lock (SerialPortInput.lockObject)
                    {
                        _recievedData.Clear();
                    }
                }

                if (_recievedData.Count >= length + 8 && headerIndex>= 0)
                {
                    byte[] msg = _recievedData.GetRange(headerIndex, length + 8).ToArray();

                    int newOffset = IRobotMessageDataAdapter.IndexOf(msg, _headerBytes.Length + 1, _headerBytes);
                    if (newOffset < 0)
                    {
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
                        
                        return bytes;
                    }
                    else
                    {
                        //可能已经丢包了，废弃这个包
                        lock (SerialPortInput.lockObject)
                        {
                            _recievedData.RemoveRange(0, headerIndex + newOffset);
                        }
                        return new byte[0];
                    }
                }
                else
                {
                    return new byte[0];
                }
            }
            catch (Exception ex)
            {
                //无效数据
                lock (SerialPortInput.lockObject)
                {
                    _recievedData.Clear();
                }

                return new byte[0];
            }
        }

        public int SerailDataLength { get; set; }
    }
}