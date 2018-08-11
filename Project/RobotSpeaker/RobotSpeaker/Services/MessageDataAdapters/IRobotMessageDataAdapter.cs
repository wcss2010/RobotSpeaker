using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSpeaker
{
    /// <summary>
    /// 消息适配器基类
    /// </summary>
    public abstract class IRobotMessageDataAdapter:IMessageDataAdapter
    {
        /// <summary>
        /// 在串口缓冲区实例中的第一个匹配项的索引。
        /// </summary>
        /// <param name="searchBytes">要查找的 System.Byte[]。</param>
        /// <returns>如果找到该字节数组，则为 searchBytes 的索引位置；如果未找到该字节数组，则为 -1。如果 searchBytes 为 null 或者长度为0，则返回值为 -1。</returns>
        public int SearchInBuffer(byte[] searchBytes)
        {
            if (SerialPortInputObject == null) { return -1; }
            if (SerialPortInputObject.BufferStream == null) { return -1; }
            if (searchBytes == null) { return -1; }
            if (SerialPortInputObject.BufferStream.Count == 0) { return -1; }
            if (searchBytes.Length == 0) { return -1; }
            if (SerialPortInputObject.BufferStream.Count < searchBytes.Length) { return -1; }
            for (int i = 0; i < SerialPortInputObject.BufferStream.Count - searchBytes.Length; i++)
            {
                if (SerialPortInputObject.BufferStream[i] == searchBytes[0])
                {
                    if (searchBytes.Length == 1) { return i; }
                    bool flag = true;
                    for (int j = 1; j < searchBytes.Length; j++)
                    {
                        if (SerialPortInputObject.BufferStream[i + j] != searchBytes[j])
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) { return i; }
                }
            }
            return -1;
        }
    }
}