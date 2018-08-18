using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Collections;
using System.Net;

namespace RobotSpeaker
{
    /// <summary>
    /// 调试服务(动作任务)
    /// </summary>
    public class DebugService
    {
        public string _listenIP = "0.0.0.0";
        public int _listenPort = 5000;

        protected SocketLibrary.Server _server;

        public void Open()
        {
            //查找空闲端口
            _listenPort = GetFirstAvailablePort();

            //创建调试Socket
            _server = new SocketLibrary.Server(_listenIP, _listenPort);
            _server.MessageReceived += _server_MessageReceived;
            _server.Connected += _server_Connected;
            _server.ConnectionClose += _server_ConnectionClose;
            _server.MessageSent += _server_MessageSent;

            try
            {
                _server.StartServer();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        void _server_MessageSent(object sender, SocketLibrary.SocketBase.MessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        void _server_ConnectionClose(object sender, SocketLibrary.SocketBase.ConCloseMessagesEventArgs e)
        {
            throw new NotImplementedException();
        }

        void _server_Connected(object sender, SocketLibrary.Connection e)
        {
            throw new NotImplementedException();
        }

        void _server_MessageReceived(object sender, SocketLibrary.SocketBase.MessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Close()
        {
            if (_server != null)
            {
                try
                {
                    _server.StopServer();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 获取第一个可用的端口号
        /// </summary>
        /// <returns></returns>
        public static int GetFirstAvailablePort()
        {
            int MAX_PORT = 6000; //系统tcp/udp端口数最大是65535            
            int BEGIN_PORT = 5000;//从这个端口开始检测

            for (int i = BEGIN_PORT; i < MAX_PORT; i++)
            {
                if (PortIsAvailable(i)) return i;
            }

            return -1;
        }

        /// <summary>
        /// 获取操作系统已用的端口号
        /// </summary>
        /// <returns></returns>
        public static IList PortIsUsed()
        {
            //获取本地计算机的网络连接和通信统计数据的信息
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

            //返回本地计算机上的所有Tcp监听程序
            IPEndPoint[] ipsTCP = ipGlobalProperties.GetActiveTcpListeners();

            //返回本地计算机上的所有UDP监听程序
            IPEndPoint[] ipsUDP = ipGlobalProperties.GetActiveUdpListeners();

            //返回本地计算机上的Internet协议版本4(IPV4 传输控制协议(TCP)连接的信息。
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            IList allPorts = new ArrayList();
            foreach (IPEndPoint ep in ipsTCP) allPorts.Add(ep.Port);
            foreach (IPEndPoint ep in ipsUDP) allPorts.Add(ep.Port);
            foreach (TcpConnectionInformation conn in tcpConnInfoArray) allPorts.Add(conn.LocalEndPoint.Port);

            return allPorts;
        }

        /// <summary>
        /// 检查指定端口是否已用
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool PortIsAvailable(int port)
        {
            bool isAvailable = true;

            IList portUsed = PortIsUsed();

            foreach (int p in portUsed)
            {
                if (p == port)
                {
                    isAvailable = false; break;
                }
            }

            return isAvailable;
        }
    }
}