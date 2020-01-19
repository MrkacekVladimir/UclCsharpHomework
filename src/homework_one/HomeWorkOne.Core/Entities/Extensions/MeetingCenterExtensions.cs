using HomeWorkOne.Core.Entities.Definitions;

namespace HomeWorkOne.Core.Entities.Extensions
{
    public static class MeetingCenterExtensions
    {
        public static IMeetingCenter SetData( this IMeetingCenter center, IMeetingCenter data )
        {
            center.Name = data.Name;
            center.Code = data.Code;
            center.Description = data.Description;            

            return center;
        }
    }
}
