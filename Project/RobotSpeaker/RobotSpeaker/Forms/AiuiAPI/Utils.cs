using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace AIUISerials
{
    public class Utils
    {
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace("0x", "");
            s = s.Replace(",", "");
            string[] ss = s.Split(' ');

            byte[] buffer = new byte[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                try
                {
                    buffer[i] = (byte)Convert.ToByte(ss[i].Substring(0, ss[i].Length), 16);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex + "\n");
                    return null;
                }
            }
            return buffer;
        }
        
        public static byte CalcCheckCode(List<byte> d)
        {
            byte checkCode = 0;
            for (int i = 0; i < d.Count - 1; i++)
            {
                checkCode += d[i];
            }
            checkCode = (byte)(~checkCode + 1);
            return checkCode;
        }

        public static byte CalcCheckCodeWithoutCode(List<byte> d)
        {
            byte checkCode = 0;
            for (int i = 0; i < d.Count; i++)
            {
                checkCode += d[i];
            }
            checkCode = (byte)(~checkCode + 1);
            return checkCode;
        }

        public static string Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            {
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        try
                        {
                            zipStream.CopyTo(resultStream);
                        }
                        catch (InvalidDataException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex + "\n");
                        }
                        return System.Text.Encoding.UTF8.GetString(resultStream.ToArray());
                    }
                }
            }
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}