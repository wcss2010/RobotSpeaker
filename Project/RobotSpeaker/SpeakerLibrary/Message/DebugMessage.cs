using Newtonsoft.Json;
using SpeakerLibrary.SportDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerLibrary.Message
{
    /// <summary>
    /// 调试消息
    /// </summary>
    public class DebugMessage
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }

        /// <summary>
        /// 指令
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public object Content { get; set; }

        public object Tag { get; set; }

        /// <summary>
        /// 转换到Json字符串
        /// </summary>
        /// <param name="dm"></param>
        /// <returns></returns>
        public static string ToJson(DebugMessage dm)
        {
            return JsonConvert.SerializeObject(dm);
        }

        /// <summary>
        /// 转到到DebugMessage对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DebugMessage FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DebugMessage>(json);
        }
    }

    /// <summary>
    /// 动作记录
    /// </summary>
    public class ActionObject
    {
        /// <summary>
        /// 动作描述
        /// </summary>
        public Robot_Actions Action { get; set; }

        /// <summary>
        /// 执行步骤
        /// </summary>
        public Robot_Steps[] StepList { get; set; }
    }

    /// <summary>
    /// 指令定义
    /// </summary>
    public class CommandConst
    {
        /// <summary>
        /// 动作执行
        /// </summary>
        public const string ActionRun = "ActionRun";

        /// <summary>
        /// 动作执行完成
        /// </summary>
        public const string ActionRunFinish = "ActionRunFinish";

        /// <summary>
        /// 上传数据库
        /// </summary>
        public const string UploadDataBase = "UploadDataBase"; 
    }
}