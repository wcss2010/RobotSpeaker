using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RobotSportTaskEditor.Tracks.MotorTrack
{
    /// <summary>
    /// 行进电机
    /// </summary>
    public class TravelTrack : MotorTrackBase
    {
        public TravelTrack(int mIndex)
        {
            _motorType = MotorTypes.C_行进电机;
            _motorIndex = mIndex;
        }

        public TravelActionTypes _travelActionType = TravelActionTypes.C_停止;
        /// <summary>
        /// 行进电机动作
        /// </summary>
        [DisplayName("行进电机动作")]
        public TravelActionTypes TravelActionType
        {
            get { return _travelActionType; }
            set 
            {
                _travelActionType = value;

                DisplayText = MotorName + "(" + value + ")";
            }
        }
    }

    /// <summary>
    /// 行进电机动作
    /// </summary>
    public enum TravelActionTypes
    {
        C_前进, C_停止,C_后退
    }
}