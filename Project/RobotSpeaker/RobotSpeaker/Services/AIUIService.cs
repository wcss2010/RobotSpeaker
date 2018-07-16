﻿using AIUISerials;
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
    /// AIUI在线语音服务(主要负责连接语音板在线端口)
    /// </summary>
    public class AIUIOnlineService
    {
        private XFJsonResolver _xfJsonResolver = new XFJsonResolver();
        /// <summary>
        /// 讯飞Json解析器
        /// </summary>
        public XFJsonResolver XfJsonResolver
        {
            get { return _xfJsonResolver; }
        }

        public AIUIOnlineService()
        {
            XfJsonResolver.XFCardLocationEvent += XfJsonResolver_XFCardLocationEvent;
            XfJsonResolver.XFCardWakeupEvent += XfJsonResolver_XFCardWakeupEvent;
            XfJsonResolver.XFCardQuestionEvent += XfJsonResolver_XFCardQuestionEvent;
        }

        void XfJsonResolver_XFCardQuestionEvent(object sender, XFQuestionEventArgs args)
        {
            if (MainService.MainUIObj.IsHandleCreated)
            {
                MainService.MainUIObj.Invoke(new MethodInvoker(delegate()
                {
                    //if (DataService.VoiceUIObj == null)
                    //{
                    //    DataService.VoiceUIObj = new VoiceUI();
                    //    DataService.VoiceUIObj.Show();
                    //}

                    if (MainService.VoiceUIObj != null)
                    {
                        if (args.Ask != null && args.Ask.Trim().Length > 0)
                        {
                            //显示问话
                            MainService.VoiceUIObj.ChatPanel.AddUserMsg(args.Ask.Trim());
                        }
                        if (args.Answer != null && args.Answer.Trim().Length > 0)
                        {
                            //显示答话
                            MainService.VoiceUIObj.ChatPanel.AddMachineMsg(args.Answer.Trim());
                        }
                    }
                }));
            }
        }

        void XfJsonResolver_XFCardWakeupEvent(object sender, EventArgs args)
        {
            if (MainService.MainUIObj.IsHandleCreated)
            {
                MainService.MainUIObj.Invoke(new MethodInvoker(delegate()
                {
                    if (MainService.VideoPlayerUIObj != null)
                    {
                        try
                        {
                            MainService.VideoPlayerUIObj.Close();
                        }
                        catch (Exception ex) { }

                        MainService.VideoPlayerUIObj = null;
                    }
                }));
            }
        }

        void XfJsonResolver_XFCardLocationEvent(object sender, XFSpeakerLocationEventArgs args)
        {
            if (MainService.MainUIObj.IsHandleCreated)
            {
                MainService.MainUIObj.Invoke(new MethodInvoker(delegate()
                {
                    if (MainService.VideoPlayerUIObj != null)
                    {
                        try
                        {
                            MainService.VideoPlayerUIObj.Close();
                        }
                        catch (Exception ex) { }

                        MainService.VideoPlayerUIObj = null;
                    }
                }));
            }
        }

        private AIUIConnection _aiuiConnection = null;
        /// <summary>
        /// AIUI连接
        /// </summary>
        public AIUIConnection AiuiConnection
        {
            get { return _aiuiConnection; }
        }

        public void Open()
        {
            //先关闭之前的
            Close();

            _aiuiConnection = new AIUIConnection(SuperObject.Config.OnlineVoicePort);
            _aiuiConnection.AIUIConnectionReceivedEvent += _aiuiConnection_AIUIConnectionReceivedEvent;

            //检查是否启动了在线模式
            if (SuperObject.Config.EnabledOnlineVoice)
            {
                _aiuiConnection.SerialPort.Connect();
            }
        }

        void _aiuiConnection_AIUIConnectionReceivedEvent(object sender, AIUIConnectionReceivedEventArgs args)
        {
            if (MainService.DeviceDebugUIObj != null)
            {
                MainService.DeviceDebugUIObj.PrintDebugLog(args.Json);
            }

            //解析Json
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
            {
                XfJsonResolver.Resolve(args.Json);
            }));
        }

        public void Close()
        {
            if (_aiuiConnection != null)
            {
                _aiuiConnection.SerialPort.Disconnect();
            }
        }
    }

    /// <summary>
    /// 唤醒
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardWakeupDelegate(object sender, EventArgs args);

    /// <summary>
    /// 讲话人角度
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardSpeakerLocationDelegate(object sender, XFSpeakerLocationEventArgs args);

    public class XFSpeakerLocationEventArgs : EventArgs
    {
        /// <summary>
        /// 角度
        /// </summary>
        public double Angle { get; set; }
    }

    /// <summary>
    /// 问答
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardQuestionDelegate(object sender, XFQuestionEventArgs args);

    public class XFQuestionEventArgs : EventArgs
    {
        /// <summary>
        /// 问
        /// </summary>
        public string Ask { get; set; }

        /// <summary>
        /// 答
        /// </summary>
        public string Answer { get; set; }
    }

    /// <summary>
    /// 讯飞Json字符解析器
    /// </summary>
    public class XFJsonResolver
    {
        /// <summary>
        /// 唤醒
        /// </summary>
        public event XFCardWakeupDelegate XFCardWakeupEvent;
        /// <summary>
        /// 角度
        /// </summary>
        public event XFCardSpeakerLocationDelegate XFCardLocationEvent;
        /// <summary>
        /// 问答
        /// </summary>
        public event XFCardQuestionDelegate XFCardQuestionEvent;

        protected void OnXFCardWakeupEvent()
        {
            if (XFCardWakeupEvent != null)
            {
                XFCardWakeupEvent(this, new EventArgs());
            }
        }

        protected void OnXFCardLocationEvent(double angle)
        {
            if (XFCardLocationEvent != null)
            {
                XFSpeakerLocationEventArgs obj = new XFSpeakerLocationEventArgs();
                obj.Angle = angle;

                XFCardLocationEvent(this, obj);
            }
        }

        protected void OnXFCardQuestionEvent(string ask, string answer)
        {
            if (XFCardQuestionEvent != null)
            {
                XFQuestionEventArgs obj = new XFQuestionEventArgs();
                obj.Ask = ask;
                obj.Answer = answer;

                XFCardQuestionEvent(this, obj);
            }
        }

        public void Resolve(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            else
            {
                try
                {
                    //解析Json字符串
                    JObject firstObj = (JObject)JsonConvert.DeserializeObject(json);

                    JToken eventStr = firstObj["type"];
                    if (eventStr.ToString().Equals("aiui_event"))
                    {
                        //是aiui_event才解析
                        JToken contentObj = firstObj["content"];
                        if (contentObj != null)
                        {
                            //判断是不是结果集消息
                            if (contentObj["result"] != null)
                            {
                                //结果集消息
                                if (contentObj["result"]["intent"] != null)
                                {
                                    JToken answers = contentObj["result"]["intent"];
                                    string askStr = string.Empty;
                                    string answerStr = string.Empty;

                                    if (answers["text"] != null)
                                    {
                                        //问的话
                                        askStr = answers["text"].ToString();
                                    }

                                    if (answers["answer"] != null && answers["answer"]["text"] != null)
                                    {
                                        //答的话
                                        answerStr = answers["answer"]["text"].ToString();
                                    }

                                    //投递答案
                                    OnXFCardQuestionEvent(askStr, answerStr);
                                }
                            }
                            else
                            {
                                //应该是某个提醒
                                if (contentObj["info"] != null)
                                {
                                    if (contentObj["info"]["wakeup_mode"] != null)
                                    {
                                        //唤醒消息
                                        OnXFCardWakeupEvent();
                                    }
                                    else if (contentObj["info"]["angle"] != null)
                                    {
                                        //角度消息
                                        OnXFCardLocationEvent(double.Parse(contentObj["info"]["angle"].ToString()));
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("解析错误！Ex:" + ex.ToString());
                }
            }
        }
    }

    /// <summary>
    /// AIUI离线语音服务(主要负责连接语音板离线端口)
    /// </summary>
    public class AiuiOfflineService
    {
        public void Open()
        {

        }

        public void Close()
        {

        }
    }
}