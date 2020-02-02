using HomeWorkOne.Core.Entities.Definitions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeWorkOne.Core.ViewModels
{
    public class MainWindowViewModel 
    {
        public CenterOverviewViewModel CenterOverview { get; set; } = new CenterOverviewViewModel( );
        public PlanningViewModel Planning { get; set; } = new PlanningViewModel( );
    }
}
