using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkOne.Core.Entities.Definitions
{
    public interface IReservation
    {
        string MeetingCenterCode { get; set; }
        string MeetingRoomCode { get; set; }
        DateTime From { get; set; }
        DateTime Until { get; set; }
        int ExpectedPersonCount { get; set; }        
        bool IsVideoConference { get; set; }
        string Customer { get; set; }
        string Note { get; set; }
    }
}
