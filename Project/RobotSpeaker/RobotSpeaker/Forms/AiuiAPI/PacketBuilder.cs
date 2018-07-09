using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIUISerials
{
    public class PacketBuilder
    {
        int seqId = 0;
        private static byte SYNC_HEAD = 0xA5;
        private static byte USER_ID = 0x01;

        private static byte SHAKE_HAND_TYPE = 0x01;
        private static byte WIFI_CONFIG_TYPE = 0x02;
        private static byte AIUI_CONFIG_TYPE = 0x03;
        private static byte AIUI_MESSAGE_TYPE = 0x04;
        private static byte CONTROL_MESSAGE_TYPE = 0x05;
        private static byte CUSTOM_DATA_TYPE = 0x2A;
        private static byte CONFIRM_MESSAGE_TYPE = 0xff;

        public List<byte> buildShakePacket()
        {
            byte[] confirmMessage = new byte[12];
            confirmMessage[0] = SYNC_HEAD;
            confirmMessage[1] = USER_ID;
            confirmMessage[2] = SHAKE_HAND_TYPE;
            confirmMessage[3] = 0x04;
            confirmMessage[4] = 0x00;
            confirmMessage[5] = (byte)(seqId & 0xff);
            confirmMessage[6] = (byte)(seqId >> 8 & 0xff);
            confirmMessage[7] = 0xA5;
            confirmMessage[8] = 0x00;
            confirmMessage[9] = 0x00;
            confirmMessage[10] = 0x00;
            List<byte> a = confirmMessage.ToList();
            int c = Utils.CalcCheckCode(confirmMessage.ToList());
            confirmMessage[11] = (byte)c;
            return confirmMessage.ToList();
        }

        public List<byte> buildConfirmPacket()
        {
            byte[] confirmMessage = new byte[12];
            confirmMessage[0] = SYNC_HEAD;
            confirmMessage[1] = USER_ID;
            confirmMessage[2] = CONFIRM_MESSAGE_TYPE;
            confirmMessage[3] = 0x04;
            confirmMessage[4] = 0x00;
            confirmMessage[5] = (byte)(seqId & 0xff);
            confirmMessage[6] = (byte)(seqId >> 8 & 0xff);
            confirmMessage[7] = 0xA5;
            confirmMessage[8] = 0x00;
            confirmMessage[9] = 0x00;
            confirmMessage[10] = 0x00;
            int c = Utils.CalcCheckCode(confirmMessage.ToList());
            confirmMessage[11] = (byte)c;
            return confirmMessage.ToList();
        }

        public List<byte> buildCmdPacket(String sendCmd)
        {
            setSeqId(seqId + 1);
            List<byte> list = new List<byte>();
            int len = sendCmd.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(CONTROL_MESSAGE_TYPE);
            list.Add((byte)(sendCmd.Length & 0xff));
            list.Add((byte)((sendCmd.Length >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            byte[] cmd = System.Text.Encoding.UTF8.GetBytes(sendCmd);
            for (int i = 0; i < len; i++)
            {
                list.Add(cmd[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;
        }

        public List<byte> buildTtsPacket(string text)
        {
            string data = CommandConst.START_TTS.Replace("******", text);
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(data);

            setSeqId(seqId + 1);
            List<byte> list = new List<byte>();
            int len = encodedBytes.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(CONTROL_MESSAGE_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            for (int i = 0; i < len; i++)
            {
                list.Add(encodedBytes[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;

        }

        public List<byte> buildWifiCfgPacket(string config)
        {
            string[] data = config.Split('|');
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] ssid = utf8.GetBytes(data[0]);
            Byte[] pass = utf8.GetBytes(data[1]);
            byte encrypt = 0x02;
            if (data[2].Equals("NONE"))
            {
                encrypt = 0x00;
            }
            else if (data[2].Equals("WEP"))
            {
                encrypt = 0x01;
            }
            else if (data[2].Equals("WPA"))
            {
                encrypt = 0x02;
            }

            setSeqId(seqId + 1);
            List<byte> list = new List<byte>();
            int len = ssid.Length + pass.Length + 4;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(WIFI_CONFIG_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));
            list.Add(0x00);
            list.Add(encrypt);
            list.Add((byte)ssid.Length);
            list.Add((byte)pass.Length);

            for (int i = 0; i < ssid.Length; i++)
            {
                list.Add(ssid[i]);
            }

            for (int i = 0; i < pass.Length; i++)
            {
                list.Add(pass[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;

        }

        public List<byte> buildAIUIConfigPacket(string config)
        {
            string[] cfg = config.Split('|');
            string aiui_config_msg = CommandConst.AIUI_CONFIG_MESSAGE.Replace("MYAPPID", cfg[0]);
            aiui_config_msg = aiui_config_msg.Replace("MYKEY", cfg[1]);
            aiui_config_msg = aiui_config_msg.Replace("MYSCENE", cfg[2]);
            if (cfg[3].Equals("Checked"))
            {
                aiui_config_msg = aiui_config_msg.Replace("MY_LAUCH_MODE", "true");
            }
            else
            {
                aiui_config_msg = aiui_config_msg.Replace("MY_LAUCH_MODE", "false");
            }

            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(aiui_config_msg);

            setSeqId(seqId + 1);

            List<byte> list = new List<byte>();
            int len = encodedBytes.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(AIUI_CONFIG_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            for (int i = 0; i < len; i++)
            {
                list.Add(encodedBytes[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;

        }

        public List<byte> buildVoiceControlPacket(Boolean isOn)
        {
            string aiui_config_msg = CommandConst.VOICE_CONTROL_MESSAGE;
            if (isOn)
            {
                aiui_config_msg = aiui_config_msg.Replace("MYVOICE", "true");
            }
            else
            {
                aiui_config_msg = aiui_config_msg.Replace("MYVOICE", "false");
            }

            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(aiui_config_msg);

            setSeqId(seqId + 1);

            List<byte> list = new List<byte>();
            int len = encodedBytes.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(CONTROL_MESSAGE_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            for (int i = 0; i < len; i++)
            {
                list.Add(encodedBytes[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;

        }

        public List<byte> buildResetWakePacket(Boolean isResetWake)
        {
            string msg = CommandConst.RESET_WAKE_MESSAGE;
            if (isResetWake)
            {
                msg = msg.Replace("MY_MSG_TYPE", "8");
            }
            else
            {
                msg = msg.Replace("MY_MSG_TYPE", "7");
            }

            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(msg);

            setSeqId(seqId + 1);

            List<byte> list = new List<byte>();
            int len = encodedBytes.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(CONTROL_MESSAGE_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            for (int i = 0; i < len; i++)
            {
                list.Add(encodedBytes[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;

        }

        public List<byte> buildSmartConfigPacket(Boolean isOn)
        {
            string smart_config = CommandConst.SMART_CONFIG_MESSAGE;

            if (isOn)
            {
                smart_config = smart_config.Replace("MYCMD", "start");
            }
            else
            {
                smart_config = smart_config.Replace("MYCMD", "stop");
                //smart_config = smart_config.Replace(",\"timeout\": 60", "");
            }

            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(smart_config);

            setSeqId(seqId + 1);

            List<byte> list = new List<byte>();
            int len = encodedBytes.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(CONTROL_MESSAGE_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            for (int i = 0; i < len; i++)
            {
                list.Add(encodedBytes[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;
        }

        public List<byte> buildACKPacket()
        {
            string s = CommandConst.ACK_MESSAGE;


            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(s);

            setSeqId(seqId + 1);

            List<byte> list = new List<byte>();
            int len = encodedBytes.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(CONTROL_MESSAGE_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            for (int i = 0; i < len; i++)
            {
                list.Add(encodedBytes[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);

            return list;
        }

        public List<byte> buildCustomDataPacket(byte[] data)
        {
            List<byte> list = new List<byte>();
            int len = data.Length;
            list.Add(SYNC_HEAD);
            list.Add(USER_ID);
            list.Add(CUSTOM_DATA_TYPE);
            list.Add((byte)(len & 0xff));
            list.Add((byte)((len >> 8) & 0xff));
            list.Add((byte)(seqId & 0xff));
            list.Add((byte)((seqId >> 8) & 0xff));

            for (int i = 0; i < len; i++)
            {
                list.Add(data[i]);
            }
            byte code = Utils.CalcCheckCodeWithoutCode(list);
            list.Add(code);
            return list;
        }

        public void setSeqId(int id)
        {
            seqId = id;
        }
    }
}