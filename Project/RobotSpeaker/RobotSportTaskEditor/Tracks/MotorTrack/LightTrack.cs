using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RobotSportTaskEditor.Tracks.MotorTrack
{
    /// <summary>
    /// 呼吸灯
    /// </summary>
    public class LightTrack : MotorTrackBase
    {
        public LightTrack(int mIndex)
        {
            _motorType = MotorTypes.C_其它设备;
            _motorIndex = mIndex;
        }

        private LightStateType _lightStateType = LightStateType.C_灭;

        /// <summary>
        /// 灯的状态
        /// </summary>
        [DisplayName("灯的状态")]
        public LightStateType LightStateType
        {
            get { return _lightStateType; }
            set
            {
                _lightStateType = value;

                DisplayText = MotorName + "(" + value + ")";
            }
        }
    }

    /// <summary>
    ///  灯的状态
    /// </summary>
    public enum LightStateType
    {
        C_灭, C_红灯, C_绿灯, C_蓝灯
    }
}