using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIUISerials
{
    public class CommandConst
    {
        public static string QUERY_AIUI_STATE = "{\"type\": \"aiui_msg\",\"content\": {\"msg_type\":1,\"arg1\":0,\"arg2\":0,\"params\":\"\"}}";

        public static string QUERY_WIFI_STATE = "{\"type\": \"status\",\"content\": {\"query\": \"wifi\"}}";

        public static string START_TTS = "{\"type\": \"tts\",\"content\": {\"action\": \"start\",\"text\": \"******\"}}";

        public static string AIUI_CONFIG_MESSAGE = "{\"type\": \"aiui_cfg\",\"content\": {\"appid\": \"MYAPPID\",\"key\": \"MYKEY\",\"scene\": \"MYSCENE\",\"launch_demo\": MY_LAUCH_MODE}}";

        public static string VOICE_CONTROL_MESSAGE = "{\"type\": \"voice\",\"content\": {\"enable_voice\":MYVOICE}}";

        public static string SMART_CONFIG_MESSAGE = "{\"type\": \"smartcfg\",\"content\": {\"cmd\": \"MYCMD\",\"timeout\": 60}}";

        public static string RESET_WAKE_MESSAGE = "{\"type\": \"aiui_msg\",\"content\": {\"msg_type\": MY_MSG_TYPE,\"arg1\": 0,\"arg2\": 0,\"params\": \"\"}}";

        public static string ACK_MESSAGE = "{\"type\": \"aiui_msg\",\"content\": {\"msg_type\": 20,\"arg1\": 0,\"arg2\": 0,\"params\": \"\"}}";
    }
}