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
        private static UserStateObject _stateObject = new UserStateObject();
        /// <summary>
        /// 用户状态对象
        /// </summary>
        public static UserStateObject StateObject
        {
            get { return TaskService._stateObject; }
        }

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

    /// <summary>
    /// 用户状态对象(用于记录当前用户说的话，说话的角度，以及手柄按下的按钮)
    /// </summary>
    public class UserStateObject
    {
        /// <summary>
        /// 当前用户说了什么
        /// </summary>
        public string CurrentUserSay { get; set; }

        /// <summary>
        /// 当前用户说话的角度
        /// </summary>
        public short CurrentUserAngle { get; set; }

        /// <summary>
        /// 当前用户手柄按下了什么按钮
        /// </summary>
        public JoystickButtonType CurrentJoyKey { get; set; }
    }
}