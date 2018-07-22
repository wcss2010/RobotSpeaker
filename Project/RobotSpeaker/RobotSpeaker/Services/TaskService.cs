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
                    List<Robot_Actions> actionList = DBInstance.DbHelper.table("Robot_Actions").select("*").getList<Robot_Actions>(new Robot_Actions());
                    if (actionList != null)
                    {
                        foreach (Robot_Actions action in actionList)
                        {
                            if (IsAcceptRun(action))
                            {
                                SendStepList(action, DBInstance.GetSteps(action.Id));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }

                try
                {
                    Thread.Sleep(200);
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="stepList"></param>
        private void SendStepList(Robot_Actions action, List<Robot_Steps> stepList)
        {
            if (action != null && stepList != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("动作名称:").Append(action.Name).Append("\n");

                foreach (Robot_Steps step in stepList)
                {
                    //编译指令
                    byte[] cmdBytes = MainService.MotorControlService.GetCommand(step);

                    if (cmdBytes != null)
                    {
                        sb.Append("-------------\n");
                        sb.Append("电机序号:").Append(step.MotorIndex).Append(",类型:").Append(step.MotorType).Append(",值:").Append(step.Value).Append("\n");
                        sb.Append("=============\n");
                        sb.Append(CRC.PrintBytesString(cmdBytes) + "\n");

                        //需要停留10ms
                        try
                        {
                            Thread.Sleep(15);
                        }
                        catch (Exception ex) { }

                        //发送指令 
                        MainService.MotorControlService.MotorPort.SendMessage(cmdBytes);
                    }
                }

                System.Console.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// 检查是否同意运行
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private bool IsAcceptRun(Robot_Actions action)
        {
            if (action != null)
            {
                if (string.IsNullOrEmpty(action.Condition))
                {
                    return false;
                }
                else
                {
                    bool result = false;

                    if (action.Condition.StartsWith("语音="))
                    {
                        result = action.Condition.Replace("语音=", string.Empty).Equals(StateObject.CurrentUserSay);
                        StateObject.CurrentUserSay = string.Empty;
                    }
                    else if (action.Condition.StartsWith("角度="))
                    {
                        string angleRangeStr = action.Condition.Replace("角度=", string.Empty);
                        string[] temps = angleRangeStr.Split(',');
                        if (temps != null && temps.Length >= 2)
                        {
                            short min = 0;
                            short max = 0;
                            try
                            {
                                min = short.Parse(temps[0]);
                            }
                            catch (Exception ex) { }
                            try
                            {
                                max = short.Parse(temps[1]);
                            }
                            catch (Exception ex) { }

                            result = StateObject.CurrentUserAngle >= min && StateObject.CurrentUserAngle <= max;
                            StateObject.CurrentUserAngle = -1;
                        }
                    }
                    else if (action.Condition.StartsWith("手柄="))
                    {
                        result = action.Condition.Replace("手柄=", string.Empty).Equals(StateObject.CurrentJoyKey.ToString());
                        StateObject.CurrentJoyKey = JoystickButtonType.None;
                    }
                    else
                    {
                        //自定义
                    }

                    return result;
                }
            }
            else
            {
                return false;
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
        public double CurrentUserAngle { get; set; }

        /// <summary>
        /// 当前用户手柄按下了什么按钮
        /// </summary>
        public JoystickButtonType CurrentJoyKey { get; set; }
    }
}