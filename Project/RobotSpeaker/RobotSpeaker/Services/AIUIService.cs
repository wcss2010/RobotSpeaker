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
using SpeakerLibrary.SportDB;
using WebSocketSharp;
using SerialPortLib;
using System.Media;
using System.Runtime.InteropServices;

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
            XfJsonResolver.XFCardSleepEvent += XfJsonResolver_XFCardSleepEvent;
            XfJsonResolver.XFCardQuestionEvent += XfJsonResolver_XFCardQuestionEvent;
            XfJsonResolver.XFCardTTSStartEvent += XfJsonResolver_XFCardTTSStartEvent;
            XfJsonResolver.XFCardTTSEndEvent += XfJsonResolver_XFCardTTSEndEvent;
            XfJsonResolver.XFCardDictateEvent += XfJsonResolver_XFCardDictateEvent;
        }

        void XfJsonResolver_XFCardSleepEvent(object sender, EventArgs args)
        {
            //设置状态
            LockUI.AIUIStatus = "listen";

            if (MainService.LockUIObj != null)
            {
                MainService.LockUIObj.UnLock();
            }
        }

        void XfJsonResolver_XFCardDictateEvent(object sender, XFQuestionEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Ask))
            {
                return;
            }

            //显示问话
            ShowUserText(args.Ask);

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
            if (string.IsNullOrEmpty(args.Answer))
            {
                return;
            }

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

            //设置状态
            LockUI.AIUIStatus = "talk";

            if (MainService.LockUIObj != null)
            {
                MainService.LockUIObj.Lock();
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
                    _aiuiConnection.Connect();

                    //AIUI播放(开)
                    if (_aiuiConnection != null)
                    {
                        _aiuiConnection.SendLauchVoiceMessage(true);
                    }
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

            //解析Json字符串
            JObject firstObj = (JObject)JsonConvert.DeserializeObject(args.Json);

            bool isNeedResolve = false;
            JToken eventToken = firstObj["type"];
            if (eventToken != null)
            {
                if (eventToken.ToString().Equals("aiui_event"))
                {
                    //是aiui_event才解析
                    JToken contentObj = firstObj["content"];
                    if (contentObj != null)
                    {
                        isNeedResolve = true;
                    }
                }
                if (eventToken.ToString().Equals("tts_event"))
                {
                    //是tts_event才解析
                    JToken contentObj = firstObj["content"];
                    if (contentObj != null)
                    {
                        isNeedResolve = true;
                    }
                }

                if (isNeedResolve)
                {
                    //解析Json
                    XfJsonResolver.Resolve(firstObj);
                }
            }
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
    /// 休眠
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void XFCardSleepDelegate(object sender, EventArgs args);

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
        /// 休眠
        /// </summary>
        public event XFCardSleepDelegate XFCardSleepEvent;

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

        protected void OnXFCardSleepEvent()
        {
            if (XFCardSleepEvent != null)
            {
                XFCardSleepEvent(this, new EventArgs());
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

        public void OnXFCardQuestionEvent(string ask, string answer)
        {
            if (XFCardQuestionEvent != null)
            {
                XFQuestionEventArgs obj = new XFQuestionEventArgs();
                obj.Ask = ask;
                obj.Answer = answer;

                XFCardQuestionEvent(this, obj);
            }
        }

        public void OnXFCardDictateEvent(string ask, string answer)
        {
            if (XFCardDictateEvent != null)
            {
                XFQuestionEventArgs obj = new XFQuestionEventArgs();
                obj.Ask = ask;
                obj.Answer = answer;

                XFCardDictateEvent(this, obj);
            }
        }

        public void Resolve(JObject firstObj)
        {
            if (firstObj == null)
            {
                return;
            }
            else
            {
                try
                {
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

                                    if (sb.Length >= 1)
                                    {
                                        OnXFCardDictateEvent(sb.ToString().Trim(), string.Empty);
                                    }
                                }
                            }
                            else
                            {
                                //应该是某个提醒
                                if (contentObj["eventType"] != null)
                                {
                                    string eventTypeStr = contentObj["eventType"].ToString();
                                    switch (eventTypeStr)
                                    {
                                        case "8":
                                            //唤醒事件(模式)
                                            if (contentObj["info"] != null)
                                            {
                                                if (contentObj["info"]["wakeup_mode"] != null)
                                                {
                                                    //唤醒消息
                                                    OnXFCardWakeupEvent();
                                                }
                                            }
                                            break;
                                        case "4":
                                            //唤醒事件(角度)
                                            if (contentObj["info"] != null)
                                            {
                                                if (contentObj["info"]["angle"] != null)
                                                {
                                                    //角度消息
                                                    OnXFCardLocationEvent(double.Parse(contentObj["info"]["angle"].ToString()));
                                                }
                                            }
                                            break;
                                        case "5":
                                            //休眠事件
                                            OnXFCardSleepEvent();
                                            break;                                        
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
        /// 离线连接
        /// </summary>
        private AIUIOffineConnection offlineConnection = null;
        private WavePlayer player = new WavePlayer();

        public void Open()
        {
            if (SuperObject.Config.EnabledOnlineVoice)
            {
                return;
            }

            try
            {
                offlineConnection = new AIUIOffineConnection(SuperObject.Config.OfflineVoiceWebSocketUrl, SuperObject.Config.OfflineVoicePort);
                if (offlineConnection.WebSocket != null)
                {
                    offlineConnection.WebSocket.OnMessage += WebSocket_OnMessage;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        void WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            string audioString = string.Empty;
            string ask = string.Empty;
            string answer = string.Empty;

            try
            {
                //解析数据
                var jtoken = JObject.Parse(e.Data);
                ask = jtoken["q"].ToString();
                answer = jtoken["a"].ToString();
                audioString = jtoken["audio"].ToString();
            }
            catch (Exception ex) { }

            //检查是否非空
            if (string.IsNullOrEmpty(ask) || string.IsNullOrEmpty(answer) || string.IsNullOrEmpty(audioString))
            {
                return;
            }

            //投递听写事件
            MainService.AiuiOnlineService.XfJsonResolver.OnXFCardDictateEvent(ask, answer);

            //投递回答事件
            MainService.AiuiOnlineService.XfJsonResolver.OnXFCardQuestionEvent(ask, answer);


            try
            {
                //播放音频
                if (player.PlayStatus == PlayStatus.Playing)
                {
                    try
                    {
                        player.Stop();
                    }
                    catch (Exception ex) { }
                }
                byte[] bytes = Convert.FromBase64String(audioString);
                player.Load(bytes, 0);
                player.Play();
            }
            catch (Exception ex) { }
        }

        public void Close()
        {
            try
            {
                offlineConnection.Dispose();
            }
            catch (Exception ex) { }
        }
    }

    public enum PlayStatus : int
    {
        Playing = 1,
        Pause = 2,
        Stop = 3
    }

    public partial class WavePlayer // 音波播放
    {
        private WAVEHDR sWaveHdr = new WAVEHDR();
        private IntPtr hWaveOut = IntPtr.Zero;
        private PlayStatus nPlayStatus = PlayStatus.Stop;
        private WAVEFORMATEX sWaveFormat = new WAVEFORMATEX();
        private DeviceNotifyPtr pfnDevNotify = null;
        private object[] mDepArgs = new object[2];

        public WavePlayer()
        {
            if (waveOutGetNumDevs() <= 0)
            {
                throw new Exception("Cannot find the your computer audio output device."); // 无法找到您电脑的音频输出设备
            }

            sWaveFormat.nSamplesPerSec = 16000; // 波形采样
            sWaveFormat.nAvgBytesPerSec = 16000 * 16 * 1; // 平均传输率
            sWaveFormat.wFormatTag = 1; // 波形格式
            sWaveFormat.nChannels = 1; // 声道
            sWaveFormat.wBitsPerSample = 16; // 采样位深
            sWaveFormat.nBlockAlign = 1 * 16 / 8; // 块对齐
            sWaveFormat.cbSize = 16; // 结构尺寸

            pfnDevNotify = DeviceNotify;
            GCHandle.Alloc(pfnDevNotify, GCHandleType.Normal);
        }

        public PlayStatus PlayStatus
        {
            get
            {
                return nPlayStatus;
            }
            set
            {
                nPlayStatus = value;
            }
        }

        public void Load(byte[] buffer, int loop)
        {
            if (hWaveOut != IntPtr.Zero && waveOutReset(hWaveOut) != MMSYSERR_NOERROR
                && waveOutClose(hWaveOut) != MMSYSERR_NOERROR)
            {
                hWaveOut = IntPtr.Zero;
                throw new Exception("Unable to turn off the audio output device."); // 无法关闭音频输出设备
            }
            if (waveOutOpen(ref hWaveOut, -1, ref sWaveFormat, pfnDevNotify,
                NULL, CALLBACK_FUNCTION) != MMSYSERR_NOERROR)
            {
                throw new Exception("Could not open audio output device."); // 无法打开音频输出设备
            }
            sWaveHdr.lpData = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
            sWaveHdr.dwBufferLength = buffer.Length;
            if (waveOutPrepareHeader(hWaveOut, ref sWaveHdr, 32) != MMSYSERR_NOERROR)
            {
                throw new Exception("Unable to prepare the waveform data block used to play."); // 无法准备用于播放的波形数据块
            }
            sWaveHdr.dwLoops = loop;
            sWaveHdr.dwFlags = WHDR_BEGINLOOP | WHDR_ENDLOOP | WHDR_PREPARED;
            mDepArgs[0] = buffer;
            mDepArgs[1] = loop;
        }

        public void Play()
        {
            if (PlayStatus == PlayStatus.Pause)
            {
                if (waveOutRestart(hWaveOut) != MMSYSERR_NOERROR)
                {
                    throw new Exception("Unable to block the output waveform data to the device."); // 无法输出波形数据块到设备
                }
            }
            else if (PlayStatus == PlayStatus.Stop)
            {
                Load((byte[])mDepArgs[0], (int)mDepArgs[1]);
            }
            if (PlayStatus != PlayStatus.Pause && PlayStatus != PlayStatus.Playing
                && waveOutWrite(hWaveOut, ref sWaveHdr, 32) != MMSYSERR_NOERROR)
            {
                throw new Exception("Unable to block the output waveform data to the device."); // 无法输出波形数据块到设备
            }
            PlayStatus = PlayStatus.Playing;
        }

        public void Pause()
        {
            if (waveOutPause(hWaveOut) != MMSYSERR_NOERROR)
            {
                throw new Exception("Unable to pause output waveform data block to device."); // 无法暂停波形数据块输出到设备
            }
            PlayStatus = PlayStatus.Pause;
        }

        public void Stop()
        {
            if (waveOutReset(hWaveOut) != MMSYSERR_NOERROR)
            {
                throw new Exception("Unable to stop output waveform data block to device."); // 无法停止波形数据块输出到设备
            }
            PlayStatus = PlayStatus.Stop;
        }

        public int Volume
        {
            get
            {
                int nWavOutVol = 0;
                if (waveOutGetVolume(hWaveOut, ref nWavOutVol) != MMSYSERR_NOERROR)
                {
                    throw new Exception("Unable to get the volume size of the output device."); // 无法获取输出设备的音量大小
                }
                int nVolLow = ((short)nWavOutVol) / (ushort.MaxValue / 100);
                int nVolHigh = (nWavOutVol >> 16) / (ushort.MaxValue / 100);
                return nVolLow >= nVolHigh ? nVolLow : nVolHigh;
            }
            set
            {
                if (waveOutSetVolume(hWaveOut, value * ushort.MaxValue / 100 << 16
                    | value * ushort.MaxValue / 100) != MMSYSERR_NOERROR)
                {
                    throw new Exception("Unable to modify the volume size of the output device."); // 无法修改输出设备的音量大小
                }
            }
        }

        private void DeviceNotify(int nWaveOutDev, int uMsg, IntPtr dwInstance, IntPtr wParam, IntPtr lParam)
        {
            if (uMsg == WOM_DONE)
            {
                PlayStatus = PlayStatus.Stop;
            }
        }
    }

    public partial class WavePlayer
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct WAVEFORMATEX
        {
            public short wFormatTag;
            public short nChannels;
            public int nSamplesPerSec;
            public int nAvgBytesPerSec;
            public short nBlockAlign;
            public short wBitsPerSample;
            public short cbSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WAVEHDR
        {
            public IntPtr lpData;
            public int dwBufferLength;
            public int dwBytesRecorded;
            public int dwUser;
            public int dwFlags;
            public int dwLoops;
            public int lpNext;
            public int nReserved;
        }

        private const int NULL = 0;
        private const int MMSYSERR_NOERROR = NULL;
        private const int WHDR_PREPARED = 2;
        private const int WHDR_ENDLOOP = 8;
        private const int WHDR_BEGINLOOP = 4;
        private const int WOM_DONE = 957;
        private const int CALLBACK_FUNCTION = 196608;

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutOpen(ref IntPtr hWaveOut,
            int uDeviceID,
            ref WAVEFORMATEX lpFormat,
            [MarshalAs(UnmanagedType.FunctionPtr)]DeviceNotifyPtr dwCallback,
            int dwInstance,
            int dwFlags);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutPrepareHeader(IntPtr hWaveOut, ref WAVEHDR lpWaveOutHdr, int uSize);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutWrite(IntPtr hWaveOut, ref WAVEHDR lpWaveOutHdr, int uSize);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutPause(IntPtr hWaveOut);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutRestart(IntPtr hWaveOut);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutReset(IntPtr hWaveOut);

        [DllImport("WinMm.dll", SetLastError = true)]
        public static extern uint waveOutClose(IntPtr hWaveOut);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutSetVolume(IntPtr hWaveOut, int dwVolume);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutGetVolume(IntPtr hWaveOut, ref int dwVolume);

        [DllImport("WinMm.dll", SetLastError = true)]
        private static extern int waveOutGetNumDevs();

        private delegate void DeviceNotifyPtr(int nWaveOutDev, int uMsg, IntPtr dwInstance, IntPtr wParam, IntPtr lParam);
    }
}