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
            try
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

                //取数据
                byte[] bytes = _recievedData.GetRange(headerIndex, 264).ToArray();

                //删除解析过的部分
                lock (SerialPortInput.lockObject)
                {
                    _recievedData.RemoveRange(0, headerIndex + length);
                }

                resAssembling = false;
                headerIndex = 0;

                if (_recievedData.Count >= 264)
                {
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
                System.Console.WriteLine(ex.ToString());

                return new byte[0];
            }
        }
    }
}