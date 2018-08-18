using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RobotSportTaskEditor.Tracks
{
    public class StartTrack : DeviceTrack
    {
        public StartTrack()
        {
            DisplayText = ">>";
            Start = 0;
            End = 30;
            BackgroundColor = Color.Green;
        }

        public override float Start
        {
            get
            {
                return 0;
            }
            set
            {
                
            }
        }

        public override float End
        {
            get
            {
                return 30;
            }
            set
            {
                
            }
        }
    }
}
