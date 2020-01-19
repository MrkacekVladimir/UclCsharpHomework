using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;

namespace HomeWorkOne.Core.Entities
{
    public class MeetingRoom: IMeetingRoom
    {
        public MeetingRoom( )
        {

        }

        public MeetingRoom( IMeetingRoom data )
        {
            this.SetData( data );
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool AllowsVideoConference { get; set; }
        public string MeetingCentreCode { get; set; }
        public MeetingCenter MeetingCentre { get; set; }
    }
}
