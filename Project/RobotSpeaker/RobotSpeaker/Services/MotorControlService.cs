using AIUISerials;
using JoyKeys.DirectInputJoy;
using RobotSpeaker.Forms;
using RobotSpeaker.Forms.Player;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using SpeakerLibrary.SportDB;
using SerialPortLib;

namespace RobotSpeaker
{
    /// <summary>
    /// 机器人电机驱动服务(主要负责连接机器人电机驱动板卡)
    /// </summary>
    public class MotorControlService
    {
        SerialPortInput _motorPort = new SerialPortInput();
        /// <summary>
        /// 电机驱动板连接
        /// </summary>
        public SerialPortInput MotorPort
        {
            get { return _motorPort; }
        }

        public void Open()
        {
            _motorPort.MessageDataAdapterObject = new MotorControlDataAdapter();
            _motorPort.SetPort(SuperObject.Config.GoPort, 115200, System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None, -1, -1);
            _motorPort.MessageReceived += _motorPost_MessageReceived;

            try
            {
                _motorPort.Connect();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        void _motorPost_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            if (args.Data != null && args.Data.Buffer != null)
            {
                System.Console.WriteLine("电机控制器返回:" + CRC.PrintBytesString(args.Data.Buffer));
            }
        }

        /// <summary>
        /// 根据Robot_Steps构造一个Comand
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public byte[] GetCommand(Robot_Steps step)
        {
            MemoryStream ms = new MemoryStream();
            byte[] result = new byte[0];

            try
            {
                //固定头部
                ms.WriteByte(0x01);
                ms.WriteByte(0x06);

                //电机序号
                byte[] indexBytes = BitConverter.GetBytes(((short)step.MotorIndex));
                Array.Reverse(indexBytes);
                ms.Write(indexBytes, 0, indexBytes.Length);

                //值
                ushort value = 0;
                switch (step.MotorType)
                {
                    case 0:
                        if (step.Value >= 0)
                        {
                            value = (ushort)(60 + step.Value);
                        }
                        else if (step.Value < 0)
                        {
                            value = (ushort)(60 + step.Value);
                        }
                        break;
                    case 1:
                        value = (ushort)step.Value;
                        break;
                    case 2:
                        value = (ushort)step.Value;
                        break;
                }
                byte[] vBytes = BitConverter.GetBytes(value);
                Array.Reverse(vBytes);
                ms.Write(vBytes, 0, vBytes.Length);

                //生成CRC
                byte[] crcs = CRC.CRC16(ms.ToArray());
                Array.Reverse(crcs);
                ms.Write(crcs, 0, crcs.Length);

                //返回byte[]
                result = ms.ToArray();
            }
            finally
            {
                ms.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="bytes"></param>
        public void SendMessage(byte[] bytes)
        {
            if (MotorPort != null)
            {
                if (MotorPort.IsConnected)
                {
                    MotorPort.SendMessage(bytes);
                }
            }
        }

        public void Close()
        {
            try
            {
                _motorPort.Disconnect();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }

    /// <summary>
    /// CRC校验
    /// </summary>
    public class CRC
    {
        /// <summary>
        /// 打印Byte数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PrintBytesString(byte[] data) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (byte b in data)
            {
                sb.Append("0x").Append(Convert.ToString(b, 16).Length == 1 ? "0" : "").Append(Convert.ToString(b, 16)).Append(",");
            }
            sb.Append("]");

            return sb.ToString();
        }

        #region  CRC16
        public static byte[] CRC16(byte[] data)
        {
            int len = data.Length;
            if (len > 0)
            {
                ushort crc = 0xFFFF;

                for (int i = 0; i < len; i++)
                {
                    crc = (ushort)(crc ^ (data[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
                    }
                }
                byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
                byte lo = (byte)(crc & 0x00FF);         //低位置

                return new byte[] { hi, lo };
            }
            return new byte[] { 0, 0 };
        }
        #endregion

        #region  ToCRC16
        public static string ToCRC16(string content)
        {
            return ToCRC16(content, Encoding.UTF8);
        }

        public static string ToCRC16(string content, bool isReverse)
        {
            return ToCRC16(content, Encoding.UTF8, isReverse);
        }

        public static string ToCRC16(string content, Encoding encoding)
        {
            return ByteToString(CRC16(encoding.GetBytes(content)), true);
        }

        public static string ToCRC16(string content, Encoding encoding, bool isReverse)
        {
            return ByteToString(CRC16(encoding.GetBytes(content)), isReverse);
        }

        public static string ToCRC16(byte[] data)
        {
            return ByteToString(CRC16(data), true);
        }

        public static string ToCRC16(byte[] data, bool isReverse)
        {
            return ByteToString(CRC16(data), isReverse);
        }
        #endregion

        #region  ToModbusCRC16
        public static string ToModbusCRC16(string s)
        {
            return ToModbusCRC16(s, true);
        }

        public static string ToModbusCRC16(string s, bool isReverse)
        {
            return ByteToString(CRC16(StringToHexByte(s)), isReverse);
        }

        public static string ToModbusCRC16(byte[] data)
        {
            return ToModbusCRC16(data, true);
        }

        public static string ToModbusCRC16(byte[] data, bool isReverse)
        {
            return ByteToString(CRC16(data), isReverse);
        }
        #endregion

        #region  ByteToString
        public static string ByteToString(byte[] arr, bool isReverse)
        {
            try
            {
                byte hi = arr[0], lo = arr[1];
                return Convert.ToString(isReverse ? hi + lo * 0x100 : hi * 0x100 + lo, 16).ToUpper().PadLeft(4, '0');
            }
            catch (Exception ex) { throw (ex); }
        }

        public static string ByteToString(byte[] arr)
        {
            try
            {
                return ByteToString(arr, true);
            }
            catch (Exception ex) { throw (ex); }
        }
        #endregion

        #region  StringToHexString
        public static string StringToHexString(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                s.Append(c.ToString("X4"));
            }
            return s.ToString();
        }
        #endregion

        #region  StringToHexByte
        private static string ConvertChinese(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                if (c <= 0 || c >= 127)
                {
                    s.Append(c.ToString("X4"));
                }
                else
                {
                    s.Append((char)c);
                }
            }
            return s.ToString();
        }

        private static string FilterChinese(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                if (c > 0 && c < 127)
                {
                    s.Append((char)c);
                }
            }
            return s.ToString();
        }

        /// <summary>
        /// 字符串转16进制字符数组
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToHexByte(string str)
        {
            return StringToHexByte(str, false);
        }

        /// <summary>
        /// 字符串转16进制字符数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isFilterChinese">是否过滤掉中文字符</param>
        /// <returns></returns>
        public static byte[] StringToHexByte(string str, bool isFilterChinese)
        {
            string hex = isFilterChinese ? FilterChinese(str) : ConvertChinese(str);

            //清除所有空格
            hex = hex.Replace(" ", "");
            //若字符个数为奇数，补一个0
            hex += hex.Length % 2 != 0 ? "0" : "";

            byte[] result = new byte[hex.Length / 2];
            for (int i = 0, c = result.Length; i < c; i++)
            {
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return result;
        }
        #endregion
    }
}