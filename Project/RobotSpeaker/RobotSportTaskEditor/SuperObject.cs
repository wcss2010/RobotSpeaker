using RobotSportTaskEditor.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSportTaskEditor
{
    public class SuperObject
    {
        /// <summary>
        /// 初化动作设计对象
        /// </summary>
        /// <param name="control"></param>
        public static void InitActionControl(ActionDesignControl control)
        {
            control.RevolveAngleLimitDict.Add(0, new RevolveAngleLimit(-55, +55));
            control.RevolveAngleLimitDict.Add(1, new RevolveAngleLimit(0, +60));
            control.RevolveAngleLimitDict.Add(2, new RevolveAngleLimit(-55, +55));
            control.RevolveAngleLimitDict.Add(3, new RevolveAngleLimit(-60, 0));
            control.RevolveAngleLimitDict.Add(4, new RevolveAngleLimit(-55, +55));
            control.RevolveAngleLimitDict.Add(5, new RevolveAngleLimit(-60, 0));
            control.RevolveAngleLimitDict.Add(6, new RevolveAngleLimit(-55, +55));
            control.RevolveAngleLimitDict.Add(7, new RevolveAngleLimit(0, +60));
            control.RevolveAngleLimitDict.Add(8, new RevolveAngleLimit(-55, +55));
            control.RevolveAngleLimitDict.Add(9, new RevolveAngleLimit(-30, +30));

        }
    }
}