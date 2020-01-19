using HomeWorkOne.Core.Entities.Definitions;

namespace HomeWorkOne.Core.Entities.Common
{
    public class MeetingCenterData : IMeetingCenter
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
