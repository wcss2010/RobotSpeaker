using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RobotSportTaskEditor.Tracks.MotorTrack
{
    /// <summary>
    /// 旋转电机
    /// </summary>
    public class RevolveTrack : MotorTrackBase
    {
        public RevolveTrack(int mIndex, short min, short max)
        {
            _motorType = MotorTypes.C_旋转电机;
            _motorIndex = mIndex;

            _minAngle = min;
            _maxAngle = max;
        }

        private short _minAngle = 0;
        /// <summary>
        /// 最小角度
        /// </summary>
        [DisplayName("最小角度")]
        public short MinAngle
        {
            get { return _minAngle; }
        }

        private short _maxAngle = 10;
        /// <summary>
        /// 最大角度
        /// </summary>
        [DisplayName("最大角度")]
        public short MaxAngle
        {
            get { return _maxAngle; }
        }

        private short _angle = 0;
        /// <summary>
        /// 旋转角度
        /// </summary>
        [DisplayName("旋转角度")]
        public short Angle
        {
            get { return _angle; }
            set 
            {
                if (value >= MinAngle && value <= MaxAngle)
                {
                    _angle = value;

                    DisplayText = MotorName + "(" + value + ")";
                }
            }
        }
    }
}