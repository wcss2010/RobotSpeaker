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
        public string MsgId { get; set; }

        public string Command { get; set; }

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

    public class ActionObject
    {
        public Robot_Actions Action { get; set; }

        public Robot_Steps[] StepList { get; set; }
    }
}