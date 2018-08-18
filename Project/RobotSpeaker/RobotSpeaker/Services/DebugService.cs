﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Management;
using System.ComponentModel;
using System.Threading;
using SpeakerLibrary.Message;

namespace RobotSpeaker
{
    /// <summary>
    /// 调试服务(动作任务)
    /// </summary>
    public class DebugService
    {
        private System.Collections.Concurrent.ConcurrentQueue<ActionObject> _taskQueues = new System.Collections.Concurrent.ConcurrentQueue<ActionObject>();
        /// <summary>
        /// 任务队列
        /// </summary>
        public System.Collections.Concurrent.ConcurrentQueue<ActionObject> TaskQueues
        {
            get { return _taskQueues; }
        }

        private string _listenIP = "0.0.0.0";
        /// <summary>
        /// 本机IP
        /// </summary>
        public string ListenIP
        {
            get { return _listenIP; }
            set { _listenIP = value; }
        }

        private int _listenPort = 4000;
        /// <summary>
        /// 本地端口
        /// </summary>
        public int ListenPort
        {
            get { return _listenPort; }
        }
        
        private SocketLibrary.Server _debugSocketServer;
        /// <summary>
        /// 调试服务Socket
        /// </summary>
        public SocketLibrary.Server DebugSocketServer
        {
            get { return _debugSocketServer; }
        }

        private BackgroundWorker _debugActionWorker = new BackgroundWorker();

        public void Open()
        {
            //查找空闲端口
            _listenPort = GetFirstAvailablePort();

            string lip = GetLocalIP();
            if (string.IsNullOrEmpty(lip))
            {
                _listenIP = "0.0.0.0";
            }
            else
            {
                _listenIP = lip;
            }

            //守护进程
            _debugActionWorker.WorkerSupportsCancellation = true;
            _debugActionWorker.DoWork += _debugActionWorker_DoWork;
            _debugActionWorker.RunWorkerAsync();

            //创建调试Socket
            _debugSocketServer = new SocketLibrary.Server(_listenIP, _listenPort);
            _debugSocketServer.MessageReceived += _server_MessageReceived;
            _debugSocketServer.Connected += _server_Connected;
            _debugSocketServer.ConnectionClose += _server_ConnectionClose;
            _debugSocketServer.MessageSent += _server_MessageSent;

            try
            {
                _debugSocketServer.StartServer();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        void _debugActionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_debugActionWorker.CancellationPending)
            {
                try
                {
                    ActionObject ao = null;
                    TaskQueues.TryDequeue(out ao);

                    if (ao != null && ao.Action.Name != null && ao.Action.Name.Length >= 1 && ao.StepList != null && ao.StepList.Length >= 1)
                    {
                        //有效任务
                        if (MainService.TaskService.RunMode == RunModeType.Debug)
                        {
                            //执行动作
                            MainService.TaskService.RunAction(ao.Action, new List<SpeakerLibrary.SportDB.Robot_Steps>(ao.StepList));
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }

        void _server_MessageSent(object sender, SocketLibrary.SocketBase.MessageEventArgs e)
        {
            System.Console.WriteLine("DebugSend:" + e.Message.ToString());
        }

        void _server_ConnectionClose(object sender, SocketLibrary.SocketBase.ConCloseMessagesEventArgs e)
        {
            if (DebugSocketServer.Connections.Count == 0)
            {
                MainService.TaskService.RunMode = RunModeType.Normal;
                System.Console.WriteLine("切换TaskService的模式为普通模式！");
            }
        }

        void _server_Connected(object sender, SocketLibrary.Connection e)
        {
            MainService.TaskService.RunMode = RunModeType.Debug;
            System.Console.WriteLine("将TaskService切换为调试模式！");
        }

        void _server_MessageReceived(object sender, SocketLibrary.SocketBase.MessageEventArgs e)
        {
            System.Console.WriteLine("收到调试信息：" + e.Message.MessageBody);

            try
            {
                SpeakerLibrary.Message.DebugMessage dm = SpeakerLibrary.Message.DebugMessage.FromJson(e.Message.MessageBody);
                switch (dm.Command)
                {
                    case "ActionRun":

                        break;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Close()
        {
            if (_debugActionWorker != null)
            {
                _debugActionWorker.CancelAsync();
                _debugActionWorker = null;
            }

            if (_debugSocketServer != null)
            {
                try
                {
                    _debugSocketServer.StopServer();
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

        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns>本机IP地址</returns>
        public string GetLocalIP()
        {
            string stringMAC = "";
            string stringIP = "";
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                if ((bool)managementObject["IPEnabled"] == true)
                {
                    stringMAC += managementObject["MACAddress"].ToString();
                    string[] IPAddresses = (string[])managementObject["IPAddress"];
                    if (IPAddresses.Length > 0)
                    {
                        stringIP = IPAddresses[0];
                    }
                }
            }

            return stringIP.ToString();  
        }
    }
}