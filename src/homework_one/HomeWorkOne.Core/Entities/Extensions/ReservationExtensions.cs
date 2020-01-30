using HomeWorkOne.Core.Entities.Definitions;

namespace HomeWorkOne.Core.Entities.Extensions
{
    public static class ReservationExtensions
    {
        public static IReservation SetData( this IReservation reservation, IReservation data )
        {
            reservation.MeetingCenterCode = data.MeetingCenterCode;
            reservation.MeetingRoomCode = data.MeetingRoomCode;
            reservation.From = data.From;
            reservation.Until = data.Until;
            reservation.ExpectedPersonCount = data.ExpectedPersonCount;
            reservation.IsVideoConference = data.IsVideoConference;
            reservation.Customer = data.Customer;
            reservation.Note = data.Note;

            return reservation;
        }
    }
}
