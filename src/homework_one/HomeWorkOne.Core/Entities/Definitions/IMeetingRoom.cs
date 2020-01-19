using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkOne.Core.Entities.Definitions
{
    public interface IMeetingRoom
    {
        string Name { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        bool AllowsVideoConference { get; set; }
    }
}
