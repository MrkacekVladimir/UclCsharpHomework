using HomeWorkOne.Core.Entities.Definitions;

namespace HomeWorkOne.Core.Entities.Extensions
{
    public static class MeetingRoomExtensions
    {
        public static IMeetingRoom SetData( this IMeetingRoom room, IMeetingRoom data )
        {
            room.Name = data.Name;
            room.Code = data.Code;
            room.Description = data.Description;
            room.AllowsVideoConference = data.AllowsVideoConference;

            return room;
        }
    }
}
