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
        private System.Collections.Concurrent.ConcurrentQueue<TaskQueueObject> _taskQueues = new System.Collections.Concurrent.ConcurrentQueue<TaskQueueObject>();
        /// <summary>
        /// 任务队列
        /// </summary>
        public System.Collections.Concurrent.ConcurrentQueue<TaskQueueObject> TaskQueues
        {
            get { return _taskQueues; }
        }

        protected BackgroundWorker _scanWorker = new BackgroundWorker();

        public TaskService()
        {
            _scanWorker.WorkerSupportsCancellation = true;
            _scanWorker.DoWork += _worker_DoWork;
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Robot_Actions> actionList = DBInstance.DbHelper.table("Robot_Actions").select("*").getList<Robot_Actions>(new Robot_Actions());

            while (!_scanWorker.CancellationPending)
            {
                try
                {
                    if (actionList != null)
                    {
                        TaskQueueObject queueObj = null;
                        TaskQueues.TryDequeue(out queueObj);

                        if (queueObj != null)
                        {
                            foreach (Robot_Actions action in actionList)
                            {
                                //检查是否符合条件
                                if (IsAcceptRun(queueObj, action))
                                {
                                    //发送指令序列
                                    SendStepList(action, DBInstance.GetSteps(action.Id));
                                }
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
                    Thread.Sleep(15);
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// 请求执行任务
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void Request(TaskActionType type, object value)
        {
            TaskQueueObject tqo = new TaskQueueObject();
            tqo.ActionType = type;
            tqo.Value = value;

            TaskQueues.Enqueue(tqo);
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

                        //发送前等待
                        sb.Append("+++++++++++++\n");
                        sb.Append("等待" + step.BeforeSleep + "毫秒");
                        try
                        {
                            Thread.Sleep((int)step.BeforeSleep);
                        }
                        catch (Exception ex) { }

                        //发送指令 
                        MainService.MotorControlService.MotorPort.SendMessage(cmdBytes);

                        //发送后等待
                        sb.Append("+++++++++++++\n");
                        sb.Append("等待" + step.AfterSleep + "毫秒");
                        try
                        {
                            Thread.Sleep((int)step.AfterSleep);
                        }
                        catch (Exception ex) { }

                        //需要停留20ms(指令之间固定时间)
                        try
                        {
                            Thread.Sleep(200);
                        }
                        catch (Exception ex) { }
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
        private bool IsAcceptRun(TaskQueueObject queueObj, Robot_Actions action)
        {
            if (action != null && queueObj != null && queueObj.Value != null)
            {
                if (string.IsNullOrEmpty(action.Condition))
                {
                    return false;
                }
                else
                {
                    bool result = false;

                    switch (queueObj.ActionType)
                    {
                        case TaskActionType.Voice:
                            if (action.Condition.StartsWith("语音="))
                            {
                                result = action.Condition.Replace("语音=", string.Empty).Equals(queueObj.Value.ToString());
                            }
                            break;
                        case TaskActionType.Angle:
                            if (action.Condition.StartsWith("角度="))
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

                                    short angle = short.Parse(queueObj.Value.ToString());
                                    result = angle >= min && angle <= max;
                                }
                            }
                            break;
                        case TaskActionType.Joy:
                            if (action.Condition.StartsWith("手柄="))
                            {
                                result = action.Condition.Replace("手柄=", string.Empty).Equals(queueObj.Value.ToString());
                            }
                            break;
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
    /// 队列对象
    /// </summary>
    public class TaskQueueObject
    {
        public TaskActionType ActionType { get; set; }

        public object Value { get; set; }
    }

    public enum TaskActionType
    {
        Voice, Angle, Joy
    }
}