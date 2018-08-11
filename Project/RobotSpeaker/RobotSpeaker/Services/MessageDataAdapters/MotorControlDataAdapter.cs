using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSpeaker
{
    public class MotorControlDataAdapter : MessageDataAdapter
    {
        public override byte[] Resolve()
        {
            byte[] results = new byte[0];
            List<byte> dataList = SerialPortInputObject.BufferStream;
            if (dataList.Count >= 8)
            {
                if (dataList[0] == 0x01 && dataList[1] == 0x06)
                {
                    results = dataList.GetRange(0, 8).ToArray();
                }
                else
                {
                    dataList.RemoveAt(0);
                }
            }

            //清空数据
            lock (SerialPortInput.lockObject)
            {
                SerialPortInputObject.BufferStream.Clear();
            }

            return results;
        }
    }
}