using AIUISerials;
using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotSpeaker
{
    public class XFOnlineMessageDataAdapter :MessageDataAdapter
    {
        public override byte[] Resolve()
        {
            byte[] results = new byte[0];

            List<byte> dataList = SerialPortInputObject.BufferStream;
            if (dataList.Count == 5)
            {
                if (dataList[0] == 0xa5 && dataList[1] == 0x01)
                {
                    SerailDataLength = ((dataList[4] & 0xff) << 8) + (dataList[3] & 0xff);
                }
                else
                {
                    dataList.RemoveAt(0);
                }
            }

            if (SerailDataLength != 0 && dataList.Count != 0 && dataList.Count == 8 + SerailDataLength)
            {
                if (dataList[0] == 0xa5 && dataList[1] == 0x01)
                {
                    if (dataList[dataList.Count - 1] == Utils.CalcCheckCode(dataList))
                    {
                        //设置SeqId
                        int id = ((dataList[6] & 0xff) << 8) + dataList[5];
                        MainService.AiuiOnlineService.AiuiConnection.packetBuilder.setSeqId(id);

                        //自动回复
                        MainService.AiuiOnlineService.AiuiConnection.SendConfirmMessage();
                        
                        //取数据
                        results = dataList.GetRange(7, SerailDataLength).ToArray();
                    }
                }
                
                //清空数据
                lock (SerialPortInput.lockObject)
                {
                    SerialPortInputObject.BufferStream.Clear();
                }
            }

            return results;
        }

        public int SerailDataLength { get; set; }
    }
}