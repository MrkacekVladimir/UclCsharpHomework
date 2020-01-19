using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;
using System.Collections.Generic;
using System.ComponentModel;

namespace HomeWorkOne.Core.Entities
{
    public class MeetingCenter: IMeetingCenter
    {
        public MeetingCenter( )
        {

        }

        public MeetingCenter( IMeetingCenter data )
        {
            this.SetData( data );
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<MeetingRoom> Rooms { get; set; }
    }
}
