using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeBeam;

namespace RobotSportTaskEditor.Tracks
{
    /// <summary>
    /// Track容器
    /// </summary>
    public class DeviceTrackParts : IMultiPartTimelineTrack
    {
        public DeviceTrackParts()
        {
            ID = "DeviceParts_" + Guid.NewGuid().ToString();
        }

        private List<ITimelineTrack> _trackElements = new List<ITimelineTrack>();
        /// <summary>
        /// 元素列表
        /// </summary>
        public List<ITimelineTrack> TrackElementList
        {
            get { return _trackElements; }
            set { _trackElements = value; }
        }

        public IEnumerable<ITimelineTrack> TrackElements
        {
            get { return _trackElements; }
        }

        /// <summary>
        /// ID
        /// </summary>
        [Browsable(false)]
        public string ID { get; set; }

        /// <summary>
        /// 显示文本
        /// </summary>
        [Browsable(false)]
        public string DisplayText { get; set; }
    }
}