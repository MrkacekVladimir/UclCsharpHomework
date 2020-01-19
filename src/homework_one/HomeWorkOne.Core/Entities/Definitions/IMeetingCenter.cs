using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkOne.Core.Entities.Definitions
{
    public interface IMeetingCenter
    {
        string Name { get; set; }
        string Code { get; set; }
        string Description { get; set; }        
    }
}
