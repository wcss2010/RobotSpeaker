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
using WebSocketSharp;
using SerialPortLib;

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
            XfJsonResolver.XFCardTTSStartEvent += XfJsonResolver_XFCardTTSStartEvent;
            XfJsonResolver.XFCardTTSEndEvent += XfJsonResolver_XFCardTTSEndEvent;
            XfJsonResolver.XFCardDictateEvent += XfJsonResolver_XFCardDictateEvent;
        }

        void XfJsonResolver_XFCardDictateEvent(object sender, XFQuestionEventArgs args)
        {
            //保存用户的问话
            MainService.TaskService.Request(TaskActionType.Voice, args.Ask);
        }

        void XfJsonResolver_XFCardTTSEndEvent(object sender, EventArgs args)
        {
            //AiuiConnection.SendLauchVoiceMessage(true);
        }

        void XfJsonResolver_XFCardTTSStartEvent(object sender, EventArgs args)
        {
            //AiuiConnection.SendLauchVoiceMessage(false);
        }

        void XfJsonResolver_XFCardQuestionEvent(object sender, XFQuestionEventArgs args)
        {
            //显示问话
            ShowUserText(args.Ask);

            //判断是否需要使用本地问答库
            if (IsUseLocalQuestion(args.Ask))
            {
                return;
            }
            else
            {
                //显示讯飞的回答
                ShowMachineText(args.Answer);
            }
        }

        void XfJsonResolver_XFCardWakeupEvent(object sender, EventArgs args)
        {
            //AiuiConnection.SendLauchVoiceMessage(true);

            if (SuperObject.Config.EnabledCloseVideoPlayerWithVoice)
            {
                //关闭视频播放器(如果有的话)
                CloseVideoPlayer();
            }
        }

        void XfJsonResolver_XFCardLocationEvent(object sender, XFSpeakerLocationEventArgs args)
        {
            if (SuperObject.Config.EnabledCloseVideoPlayerWithVoice)
            {
                //关闭视频播放器(如果有的话)
                CloseVideoPlayer();
            }

            //保存说话的角度
            MainService.TaskService.Request(TaskActionType.Angle, args.Angle);
        }

        /// <summary>
        /// 显示人讲话的文本
        /// </summary>
        /// <param name="txt"></param>
        public void ShowUserText(string txt)
        {
            if (MainService.MainUIObj.IsHandleCreated)
            {
                MainService.MainUIObj.Invoke(new MethodInvoker(delegate()
                {
                    if (MainService.VoiceUIObj != null)
                    {
                        if (txt != null && txt.Trim().Length > 0)
                        {
                            //显示问话
                            MainService.VoiceUIObj.ChatPanel.AddUserMsg(txt.Trim());
                        }
                    }
                }));
            }
        }

        /// <summary>
        /// 显示机器回答的文本
        /// </summary>
        /// <param name="txt"></param>
        public void ShowMachineText(string txt)
        {
            if (MainService.MainUIObj.IsHandleCreated)
            {
                MainService.MainUIObj.Invoke(new MethodInvoker(delegate()
                {
                    if (MainService.VoiceUIObj != null)
                    {
                        if (txt != null && txt.Length > 0)
                        {
                            //显示答话
                            MainService.VoiceUIObj.ChatPanel.AddMachineMsg(txt.Trim());
                        }
                    }
                }));
            }
        }

        /// <summary>
        /// 让语音卡朗读一段文字
        /// </summary>
        /// <param name="txt"></param>
        public void TTSPlay(string txt)
        {
            if (MainService.MainUIObj != null)
            {
                if (MainService.MainUIObj.IsHandleCreated)
                {
                    MainService.MainUIObj.Invoke(new MethodInvoker(delegate()
                        {
                            if (SuperObject.Config.EnabledOnlineVoice)
                            {
                                //在线模式播放
                                MainService.AiuiOnlineService.AiuiConnection.SendTTSMessage(txt);
                            }
                            else
                            {
                                //离线模式播放

                            }
                        }));
                }
            }
        }

        /// <summary>
        /// 是否可以使用本地问答库
        /// </summary>
        /// <param name="ask"></param>
        /// <returns></returns>
        public bool IsUseLocalQuestion(string ask)
        {
            bool result = false;
            Robot_Questions question = DBInstance.GetQuestion(ask);

            if (question != null && question.Ask != null && question.Answer != null)
            {
                //显示回答
                ShowMachineText(question.Answer);

                //播放回答语音
                TTSPlay(question.Answer);

                //确定使用本地问答库
                result = true;
            }
            else
            {
                //仍然使用讯飞问答结果
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 关闭视频播放器(如果有的话)
        /// </summary>
        private void CloseVideoPlayer()
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
                try
                {
                    _aiuiConnection.SerialPort.Connect();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }

        void _aiuiConnection_AIUIConnectionReceivedEvent(object sender, AIUIConnectionReceivedEventArgs args)
        {
            try
            {
                if (MainService.DeviceDebugUIObj != null)
                {
                    MainService.DeviceDebugUIObj.PrintDebugLog(args.Json);
                }
            }
            catch (Exception ex) { }

            //解析Json
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
            {
                try
                {
                    XfJsonResolver.Resolve(args.Json);
                }
                catch (Exception ex) { }
            }));
        }

        public void Close()
        {
            if (_aiuiConnection != null)
            {
                try
                {
                    _aiuiConnection.SerialPort.Disconnect();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }
    }

    /// <summary>
    /// TTS开始
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardTTSStartDelegate(object sender, EventArgs args);

    /// <summary>
    /// TTS结束
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardTTSEndDelegate(object sender, EventArgs args);

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
        /// TTS开始事件
        /// </summary>
        public event XFCardTTSStartDelegate XFCardTTSStartEvent;

        /// <summary>
        /// TTS结束事件
        /// </summary>
        public event XFCardTTSEndDelegate XFCardTTSEndEvent;

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

        public event XFCardQuestionDelegate XFCardDictateEvent;

        protected void OnXFCardTTSStartEvent()
        {
            if (XFCardTTSStartEvent != null)
            {
                XFCardTTSStartEvent(this, new EventArgs());
            }
        }

        protected void OnXFCardTTSEndEvent()
        {
            if (XFCardTTSEndEvent != null)
            {
                XFCardTTSEndEvent(this, new EventArgs());
            }
        }

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

        protected void OnXFCardDictateEvent(string ask, string answer)
        {
            if (XFCardDictateEvent != null)
            {
                XFQuestionEventArgs obj = new XFQuestionEventArgs();
                obj.Ask = ask;
                obj.Answer = answer;

                XFCardDictateEvent(this, obj);
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
                                else if (contentObj["result"]["text"] != null)
                                {
                                    JToken listen = contentObj["result"]["text"];
                                    StringBuilder sb = new StringBuilder();
                                    GetVoiceString(sb, listen, "w");

                                    if (sb.Length >= 2)
                                    {
                                        OnXFCardDictateEvent(sb.ToString().Trim(), string.Empty);
                                    }
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
                    else if (eventStr.ToString().Equals("tts_event"))
                    {
                        JToken contentObj = firstObj["content"];
                        if (contentObj != null)
                        {
                            if (contentObj["eventType"] != null)
                            {
                                if (contentObj["eventType"].ToString().Equals("0"))
                                {
                                    OnXFCardTTSStartEvent();
                                }
                                else
                                {
                                    OnXFCardTTSEndEvent();
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

        /// <summary>
        /// 遍历Json子节点，找出所有字符串
        /// </summary>
        /// <param name="stringBuffer"></param>
        /// <param name="parent"></param>
        /// <param name="fieldName"></param>
        protected void GetVoiceString(StringBuilder stringBuffer, JToken parent, string fieldName)
        {
            foreach (JToken t in parent.Children())
            {
                GetVoiceString(stringBuffer, t, fieldName);

                JProperty pp = t as JProperty;
                if (pp != null && pp.Name != null && pp.Name.Equals(fieldName))
                {
                    stringBuffer.Append(pp.Value);
                }
            }
        }
    }

    /// <summary>
    /// AIUI离线语音服务(主要负责连接语音板离线端口)
    /// </summary>
    public class AiuiOfflineService
    {
        /// <summary>
        /// WebSocket
        /// </summary>
        private WebSocket _webSocket;
        /// <summary>
        /// SerialPort
        /// </summary>
        private SerialPortInput _portObject;

        public void Open()
        {
            if (SuperObject.Config.EnabledOnlineVoice)
            {
                return;
            }

            //关闭先前的
            Close();

            // 开启一个WebSocket
            try
            {
                _webSocket = new WebSocket(SuperObject.Config.OfflineVoiceWebSocketUrl);
                _webSocket.OnMessage += _webSocket_OnMessage;
                _webSocket.Connect();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

            //开启一个PortObject
            _portObject = new SerialPortInput();
            _portObject.MessageDataAdapterObject = new XFOfflineMessageDataAdapter();
            _portObject.EnabledPrintReceiveLog = false;
            _portObject.MessageReceived += _portObject_MessageReceived;
            _portObject.SetPort(SuperObject.Config.OfflineVoicePort, 921600, System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None, -1, -1);
            try
            {
                _portObject.Connect();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        void _portObject_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            //发送语音数据
            if (_webSocket != null && _webSocket.IsAlive)
            {
                _webSocket.Send(args.Data);
            }
        }

        /// <summary>
        /// 离线模式返回字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _webSocket_OnMessage(object sender, MessageEventArgs e)
        {

        }

        public void Close()
        {
            try
            {
                _webSocket.Close();
            }
            catch (Exception ex) { }

            try
            {
                _portObject.Disconnect();
            }
            catch (Exception ex) { }
        }
    }
}