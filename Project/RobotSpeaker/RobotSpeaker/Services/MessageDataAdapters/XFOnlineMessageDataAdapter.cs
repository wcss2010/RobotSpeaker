using AIUISerials;
using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSpeaker
{
    public class XFOnlineMessageDataAdapter :MessageDataAdapter
    {
        bool resAssembling = false;
        int headerIndex = 0;

        public override byte[] Resolve()
        {
            try
            {
                List<byte> _recievedData = this.SerialPortInputObject.BufferStream;
                if (!resAssembling)
                {
                    while (headerIndex + 8 < _recievedData.Count && !(_recievedData[headerIndex] == 0xa5 && _recievedData[headerIndex + 1] == 0x01))
                    {
                        headerIndex++;
                    }
                    lock (SerialPortInput.lockObject)
                    {
                        if (headerIndex >= _recievedData.Count)
                        {
                            _recievedData.Clear();
                        }
                    }
                    resAssembling = true;
                }

                if (headerIndex + 8 >= _recievedData.Count)
                {
                    Thread.Sleep(10);
                }

                // 帧长度=数据区长度+1
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

                    resAssembling = false;
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