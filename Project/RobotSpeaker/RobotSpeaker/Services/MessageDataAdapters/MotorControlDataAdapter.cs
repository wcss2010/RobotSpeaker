using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSpeaker
{
    public class MotorControlDataAdapter : IRobotMessageDataAdapter
    {
        private byte[] _headerBytes = new byte[] { 0x01, 0x06 };

        public override byte[] Resolve()
        {
            byte[] results = new byte[0];
            List<byte> _receiveData = SerialPortInputObject.BufferStream;

            //查找开头
            int headerIndex = SearchInBuffer(_headerBytes);
            if (headerIndex >= 0)
            {
                //有效值
                if (headerIndex + 8 > _receiveData.Count)
                {
                    Thread.Sleep(10);
                }

                //取数据
                results = _receiveData.GetRange(headerIndex, 8).ToArray();

                //删除解析过的数据
                lock (SerialPortInput.lockObject)
                {
                    _receiveData.RemoveRange(0, headerIndex + 8);
                }
            }
            else
            {
                //无效的值，丢弃这些数据
                lock (SerialPortInput.lockObject)
                {
                    _receiveData.Clear();
                }
            }

            return results;
        }
    }
}