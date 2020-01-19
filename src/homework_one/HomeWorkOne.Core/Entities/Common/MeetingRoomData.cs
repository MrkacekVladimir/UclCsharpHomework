using HomeWorkOne.Core.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkOne.Core.Entities.Common
{
    public class MeetingRoomData : IMeetingRoom
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool AllowsVideoConference { get; set; }
        public string MeetingCentreCode { get; set; }
    }
}
