using System;
using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;

namespace HomeWorkOne.Core.Entities
{
    public class Reservation: IReservation
    {
        public Reservation( )
        {

        }

        public Reservation( IReservation data )
        {
            this.SetData( data );
        }

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
