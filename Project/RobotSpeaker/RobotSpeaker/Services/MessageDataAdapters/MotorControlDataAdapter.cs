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

        public override IMessageEntity Resolve()
        {
            DataBufferObject _receiveData = BufferStream;

            //查找开头
            int headerIndex = _receiveData.IndexOf(_headerBytes);
            if (headerIndex >= 0)
            {
                //有效值
                if (headerIndex + 8 > _receiveData.Buffer.Count)
                {
                    Thread.Sleep(10);
                    return null;
                }
                else
                {
                    //取数据
                    byte[] results = _receiveData.GetAndRemoveRangeWithLock(headerIndex, 8);
                    return new IMessageEntity(results, DateTime.Now.Ticks, 8, null);
                }
            }
            else
            {
                //无效的值，丢弃这些数据
                _receiveData.ClearWithLock();
                return null;
            }
        }
    }
}