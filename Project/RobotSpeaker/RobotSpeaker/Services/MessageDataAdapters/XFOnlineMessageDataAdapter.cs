using AIUISerials;
using SerialPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotSpeaker
{
    public class XFOnlineMessageDataAdapter : IRobotMessageDataAdapter
    {
        private byte[] _headerBytes = new byte[] { 0xA5, 0x01 };
        private int headerIndex = 0;
        private int SerailDataLength = 0;

        public override IMessageEntity Resolve()
        {
            DataBufferObject _recievedData = this.SerialPortInputObject.BufferStream;
            try
            {
                //尝试查找包头
                headerIndex = _recievedData.IndexOf(_headerBytes);
                if (headerIndex >= 0)
                {
                    if (headerIndex + 8 >= _recievedData.Buffer.Count)
                    {
                        Thread.Sleep(10);
                        return null;
                    }
                    else
                    {
                        int length = ((_recievedData.Buffer[headerIndex + 4] & 0xff) << 8) + (_recievedData.Buffer[headerIndex + 3] & 0xff);
                        if (length > 0)
                        {
                            if (headerIndex + length + 8 > _recievedData.Buffer.Count)
                            {
                                Thread.Sleep(10);
                            }
                        }
                        else
                        {
                            //无效数据
                            _recievedData.ClearWithLock();
                        }

                        if (_recievedData.Buffer.Count >= length + 8)
                        {
                            byte[] msg = _recievedData.Buffer.GetRange(headerIndex, length + 8).ToArray();
                            int newOffset = IRobotMessageDataAdapter.IndexOf(msg, _headerBytes.Length + 1, _headerBytes);
                            if (newOffset < 0)
                            {
                                int id = 0;
                                //解析SeqID并且回复确认
                                if (msg[msg.Length - 1] == Utils.CalcCheckCode(new List<byte>(msg)))
                                {
                                    //设置SeqId
                                    id = ((msg[6] & 0xff) << 8) + msg[5];
                                    MainService.AiuiOnlineService.AiuiConnection.packetBuilder.setSeqId(id);

                                    //自动回复
                                    MainService.AiuiOnlineService.AiuiConnection.SendConfirmMessage();
                                }

                                //取数据
                                byte[] bytes = new byte[0];
                                if (msg[2] == 0x04)
                                {
                                    bytes = _recievedData.Buffer.GetRange(headerIndex + 7, length).ToArray();

                                    //删除解析过的数据
                                    _recievedData.RemoveRangeWithLock(0, headerIndex + length + 8);

                                    return new IMessageEntity(bytes, id, bytes.Length, null);
                                }
                                else
                                {
                                    //删除解析过的数据
                                    _recievedData.RemoveRangeWithLock(0, headerIndex + length + 8);

                                    return null;
                                }
                            }
                            else
                            {
                                //可能已经丢包了，废弃这个包
                                _recievedData.RemoveRangeWithLock(0, headerIndex + newOffset);                                
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    //无效数据
                     _recievedData.ClearWithLock();                    

                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}