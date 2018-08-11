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
            List<byte> _recievedData = this.SerialPortInputObject.BufferStream;
            if (!resAssembling)
            {
                while (headerIndex + 7 < _recievedData.Count && !(_recievedData[headerIndex] == 0xa5 && _recievedData[headerIndex + 1] == 0x01))
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

            if (headerIndex + 7 >= _recievedData.Count)
            {
                Thread.Sleep(10);
            }

            // 帧长度=数据区长度+1
            int length = ((_recievedData[4] & 0xff) << 8) + (_recievedData[3] & 0xff);
            if (headerIndex + length + 7 > _recievedData.Count)
            {
                Thread.Sleep(10);
            }

            if (_recievedData.Count >= length + 7)
            {
                if (_recievedData[_recievedData.Count - 1] == Utils.CalcCheckCode(_recievedData))
                {
                    //设置SeqId
                    int id = ((_recievedData[headerIndex + 6] & 0xff) << 8) + _recievedData[headerIndex + 5];
                    MainService.AiuiOnlineService.AiuiConnection.packetBuilder.setSeqId(id);

                    //自动回复
                    MainService.AiuiOnlineService.AiuiConnection.SendConfirmMessage();
                }

                return _recievedData.GetRange(headerIndex + 7, length).ToArray();
            }
            else
            {
                return new byte[0];
            }
        }

        public int SerailDataLength { get; set; }
    }
}