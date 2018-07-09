using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace AIUISerials
{
    public class SerialPortEx
    {
        public delegate void EventHandle(byte[] readBuffer);
        public event EventHandle DataReceived;

        public SerialPort serialPort;
        Thread thread;
        volatile bool _keepReading;

        public SerialPortEx()
        {
            serialPort = new SerialPort();
            thread = null;
            _keepReading = false;
        }

        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        private void StartReading()
        {
            if (!_keepReading)
            {
                _keepReading = true;
                thread = new Thread(new ThreadStart(ReadPort));
                thread.Start();
            }
        }

        private void StopReading()
        {
            if (_keepReading)
            {
                _keepReading = false;
                thread.Join();
                thread = null;
            }
        }

        private void ReadPort()
        {
            while (_keepReading)
            {
                if (serialPort.IsOpen)
                {
                    int count = serialPort.BytesToRead;
                    if (count > 0)
                    {
                        byte[] readBuffer = new byte[count];
                        //Console.WriteLine("一次接收了 " + count);
                        try
                        {
                            Application.DoEvents();
                            serialPort.Read(readBuffer, 0, count);
                            if (DataReceived != null)
                                DataReceived(readBuffer);

                        }
                        catch (TimeoutException)
                        {
                        }
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
        }

        public void Open()
        {
            Close();
            serialPort.Open();
            if (serialPort.IsOpen)
            {
                StartReading();
            }
            else
            {
                MessageBox.Show("串口打开失败！");
            }
        }

        public void Close()
        {
            StopReading();
            serialPort.Close();
        }

        public void WritePort(byte[] send, int offSet, int count)
        {
            if (IsOpen)
            {
                serialPort.Write(send, offSet, count);
            }
        }
    }
}