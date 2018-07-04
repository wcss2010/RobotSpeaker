using RobotSpeaker.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RobotSpeaker
{
    /// <summary>
    /// 数据服务
    /// </summary>
    public class DataService
    {
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
        /// 初始化
        /// </summary>
        public static void Init()
        {
            
        }
    }
}