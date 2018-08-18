using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using TimeBeam;

namespace RobotSportTaskEditor.Tracks
{
    public class DeviceTrack : ITimelineTrack
    {
        public DeviceTrack()
        {
            ID = "Device_" + Guid.NewGuid().ToString();
            Start = 0;
            End = 10;
            BackgroundColor = Color.Blue;
            ForeColor = Color.White;
            DisplayText = "未知";
            Font = new Font("宋体", 12);
        }
        
        /// <summary>
        /// 背景颜色
        /// </summary>
        [Browsable(false)]
        public System.Drawing.Color BackgroundColor { get; set; }

        /// <summary>
        /// 结束位置
        /// </summary>
        [Browsable(false)]
        public virtual float End { get; set; }

        /// <summary>
        /// 显示字体
        /// </summary>
        [Browsable(false)]
        public System.Drawing.Font Font { get; set; }

        /// <summary>
        /// 字体颜色
        /// </summary>
        [Browsable(false)]
        public System.Drawing.Color ForeColor { get; set; }

        /// <summary>
        /// 开始位置
        /// </summary>
        [Browsable(false)]
        public virtual float Start { get; set; }

        /// <summary>
        /// 显示文本
        /// </summary>
        [Browsable(false)]
        public string DisplayText { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [Browsable(false)]
        public string ID { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Browsable(false)]
        public Image DisplayIcon { get; set; }
    }
}