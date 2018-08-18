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

namespace RobotSpeaker
{
    /// <summary>
    /// 数据服务
    /// </summary>
    public class MainService
    {
        private static JoystickButtonType LastJoystickButtonType = JoystickButtonType.None;

        /// <summary>
        /// 图片缓存
        /// </summary>
        public static Dictionary<string, Image> imageDict = new Dictionary<string, Image>();

        /// <summary>
        /// 载入图片（带缓存）
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Image GetImage(string filePath)
        {
            if (imageDict.ContainsKey(filePath))
            {
                return imageDict[filePath];
            }
            else
            {
                try
                {
                    Image img = Image.FromFile(filePath);
                    imageDict[filePath] = img;

                    return imageDict[filePath];
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 聊天界面对象
        /// </summary>
        public static VoiceUI VoiceUIObj { get; set; }

        /// <summary>
        /// 配置界面对象
        /// </summary>
        public static ConfigUI ConfigUIObj { get; set; }

        /// <summary>
        /// 视频播放器界面对象
        /// </summary>
        public static VideoAndAudioPlayerUI VideoPlayerUIObj { get; set; }

        /// <summary>
        /// 设备调试界面对象
        /// </summary>
        public static DeviceDebugUI DeviceDebugUIObj { get; set; }

        /// <summary>
        /// 主窗体
        /// </summary>
        public static MainUI MainUIObj { get; set; }

        /// <summary>
        /// 手柄服务
        /// </summary>
        private static JoystickService _joystickServiceObj = new JoystickService();
        /// <summary>
        /// 游戏手柄服务(主要负责处理游戏手柄的按键)
        /// </summary>
        public static JoystickService JoystickServiceObj
        {
            get { return MainService._joystickServiceObj; }
        }

        private static AIUIOnlineService _aiuiOnlineService = new AIUIOnlineService();
        /// <summary>
        /// AIUI在线语音服务(主要负责连接语音板在线端口)
        /// </summary>
        public static AIUIOnlineService AiuiOnlineService
        {
            get { return MainService._aiuiOnlineService; }
        }

        private static MotorControlService _motorControlService = new MotorControlService();
        /// <summary>
        /// 机器人电机驱动服务(主要负责连接机器人电机驱动板卡)
        /// </summary>
        public static MotorControlService MotorControlService
        {
            get { return MainService._motorControlService; }
        }

        private static AiuiOfflineService _aiuiOfflineService = new AiuiOfflineService();
        /// <summary>
        /// AIUI离线语音服务(主要负责连接语音板离线端口)
        /// </summary>
        public static AiuiOfflineService AiuiOfflineService
        {
            get { return MainService._aiuiOfflineService; }
        }

        private static TaskService _taskService = new TaskService();
        /// <summary>
        /// 机器人任务服务(主要负责根据语音+语音角度+手柄等方面的信息执行符合条件任务)
        /// </summary>
        public static TaskService TaskService
        {
            get { return MainService._taskService; }
        }
        
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            DBInstance.Init(Path.Combine(Application.StartupPath, "static.db"));
        }

        /// <summary>
        /// 打开服务 
        /// </summary>
        public static void Open(MainUI mains)
        {
            MainUIObj = mains;

            //打开手柄服务
            _joystickServiceObj.JoystickPressEvent += JoystickService_JoystickPressEvent;
            _joystickServiceObj.Open(MainUIObj);

            //打开在线语音服务
            _aiuiOnlineService.Open();

            //打开离线语音服务
            _aiuiOfflineService.Open();

            //打开电机驱动服务
            _motorControlService.Open();

            //打开任务服务
            _taskService.Open();
        }

        private static void JoystickService_JoystickPressEvent(object sender, JoystickPressEventArgs args)
        {
            //保存当前按钮状态
            if (SuperObject.Config.CurrentGoType == GoType.Joy && args.ButtonType != JoystickButtonType.None)
            {
                if (args.ButtonType == JoystickButtonType.MiddleCenter)
                {
                    if (LastJoystickButtonType != JoystickButtonType.TopLeft && LastJoystickButtonType != JoystickButtonType.TopCenter && LastJoystickButtonType != JoystickButtonType.TopRight && LastJoystickButtonType != JoystickButtonType.MiddleLeft && LastJoystickButtonType != JoystickButtonType.MiddleRight && LastJoystickButtonType != JoystickButtonType.BottomLeft && LastJoystickButtonType != JoystickButtonType.BottomCenter && LastJoystickButtonType != JoystickButtonType.MiddleRight)
                    {
                        return;
                    }
                }

                if (LastJoystickButtonType == args.ButtonType)
                {
                    return;
                }

                LastJoystickButtonType = args.ButtonType;
                TaskService.Request(TaskActionType.Joy, args.ButtonType);
            }

            #region 向ConfigUI界面中的手柄测试界面传递按键指令
            if (MainUIObj != null)
            {
                if (MainUIObj.IsHandleCreated)
                {
                    MainUIObj.Invoke(new MethodInvoker(delegate()
                        {
                            if (ConfigUIObj != null)
                            {
                                ConfigUIObj.JoystickStateInfo.ProcessorJoystickButtons(args);
                            }
                        }));
                }
            }
            #endregion
        }

        /// <summary>
        /// 关闭服务
        /// </summary>
        public static void Close()
        {
            //关闭手柄服务
            _joystickServiceObj.Close();

            //关闭在线语音服务
            _aiuiOnlineService.Close();

            //关闭离线语音服务
            _aiuiOfflineService.Close();

            //关闭电机驱动服务
            _motorControlService.Close();

            //关闭任务服务
            _taskService.Close();
        }

        /// <summary>
        /// 重置本地服务
        /// </summary>
        public static void Reset()
        {
            //重置AIUI在线服务
            _aiuiOnlineService.Close();
            _aiuiOnlineService.Open();

            //重置AIUI离线服务
            _aiuiOfflineService.Close();
            _aiuiOfflineService.Open();

            //重置运动服务
            _motorControlService.Close();
            _motorControlService.Open();
        }
    }
}