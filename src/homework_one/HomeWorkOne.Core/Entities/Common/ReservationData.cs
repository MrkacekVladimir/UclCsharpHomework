using HomeWorkOne.Core.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkOne.Core.Entities.Common
{
    public class ReservationData : IReservation
    {
        public string MeetingCenterCode { get; set; }
        public string MeetingRoomCode { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public int ExpectedPersonCount { get; set; }
        public bool IsVideoConference { get; set; }
        public string Customer { get; set; }
        public string Note { get; set; }
    }
}
