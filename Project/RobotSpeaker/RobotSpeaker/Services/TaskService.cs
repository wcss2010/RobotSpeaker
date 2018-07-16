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
using RobotSpeaker.SportDB;

namespace RobotSpeaker
{
    /// <summary>
    /// 机器人任务服务(主要负责根据语音+语音角度+手柄等方面的信息执行符合条件任务)
    /// </summary>
    public class TaskService
    {
        protected BackgroundWorker _scanWorker = new BackgroundWorker();

        public TaskService()
        {
            _scanWorker.WorkerSupportsCancellation = true;
            _scanWorker.DoWork += _worker_DoWork;
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_scanWorker.CancellationPending)
            {


                try
                {
                    Thread.Sleep(200);
                }
                catch (Exception ex) { }
            }
        }

        public void Open()
        {
            if (_scanWorker.IsBusy)
            {
                return;
            }

            _scanWorker.RunWorkerAsync();
        }

        public void Close()
        {
            _scanWorker.CancelAsync();
        }
    }
}