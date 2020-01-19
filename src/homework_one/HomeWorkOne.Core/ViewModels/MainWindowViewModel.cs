using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HomeWorkOne.Core.ViewModels
{
    public class MainWindowViewModel
    {
        public MeetingCenterModel SelectedMeetingCentre { get; set; }
        public MeetingRoomModel SelectedMeetingRoom { get; set; }

        public ObservableCollection<MeetingCenterModel> MeetingCenters { get; set; } = new ObservableCollection<MeetingCenterModel>( );

        private Dictionary<MeetingCenterModel, ObservableCollection<MeetingRoomModel>> _meetingRooms { get; set; } = new Dictionary<MeetingCenterModel, ObservableCollection<MeetingRoomModel>>( );
        public ObservableCollection<MeetingRoomModel> GetMeetingRooms( MeetingCenterModel meetingCenter )
        {
            if(_meetingRooms.ContainsKey( meetingCenter ) )
            {
                return _meetingRooms[ meetingCenter ];
            }
            else
            {
                var collection = new ObservableCollection<MeetingRoomModel>( );
                _meetingRooms[ meetingCenter ] = collection;

                return collection;
            }            
        }        
    }
}
