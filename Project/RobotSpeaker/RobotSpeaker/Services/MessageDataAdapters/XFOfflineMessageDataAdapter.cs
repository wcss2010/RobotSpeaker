using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSpeaker
{
    public class XFOfflineMessageDataAdapter : IRobotMessageDataAdapter
    {
        private byte[] _headerBytes = new byte[] { 0xFD, 0x00, 0x80, 0x00 };

        public override byte[] Resolve()
        {
            try
            {
                List<byte> _recievedData = this.SerialPortInputObject.BufferStream;
                int headerIndex = SearchInBuffer(_headerBytes);
                if (headerIndex >= 0)
                {
                    //有效
                    // 帧长度=数据区长度+1
                    int length = 264;
                    if (headerIndex + length > _recievedData.Count)
                    {
                        return new byte[0];
                    }

                    //取数据
                    byte[] bytes = _recievedData.GetRange(headerIndex, length).ToArray();

                    //删除解析过的部分
                    lock (SerialPortInput.lockObject)
                    {
                        _recievedData.RemoveRange(0, headerIndex + length);
                    }

                    return bytes;

                }
                else
                {
                    //无效数据
                    lock (SerialPortInput.lockObject)
                    {
                        _recievedData.Clear();
                    }

                    return new byte[0];
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());

                return new byte[0];
            }
        }
    }
}