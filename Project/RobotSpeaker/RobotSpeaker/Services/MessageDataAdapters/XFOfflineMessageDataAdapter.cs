using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSpeaker
{
    public class XFOfflineMessageDataAdapter : MessageDataAdapter
    {
        bool resAssembling = false;
        int headerIndex = 0;

        public override byte[] Resolve()
        {
            List<byte> _recievedData = this.SerialPortInputObject.BufferStream;
            if (!resAssembling)
            {
                while (headerIndex + 3 < _recievedData.Count && !(_recievedData[headerIndex] == 0xFD && _recievedData[headerIndex + 1] == 0x00 && _recievedData[headerIndex + 2] == 0x80 && _recievedData[headerIndex + 3] == 0x00))
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

            if (headerIndex + 2 >= _recievedData.Count)
            {
                Thread.Sleep(10);
            }

            // 帧长度=数据区长度+1
            int length = 264;
            if (headerIndex + length > _recievedData.Count)
            {
                Thread.Sleep(10);
            }

            if (_recievedData.Count >= 264)
            {
                return _recievedData.GetRange(headerIndex, 264).ToArray();
            }
            else
            {
                return new byte[0];
            }
        }
    }
}