using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeWorkOne.Core.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MeetingCenterModel _selectedMeetingCenter;

        public MeetingCenterModel SelectedMeetingCenter
        {
            get { return _selectedMeetingCenter; }
            set
            {
                _selectedMeetingCenter = value;
                OnPropertyChanged( nameof( SelectedMeetingCenter ) );
            }
        }

        private MeetingRoomModel _selectedMeetingRoom;

        public MeetingRoomModel SelectedMeetingRoom
        {
            get { return _selectedMeetingRoom; }
            set
            {
                _selectedMeetingRoom = value;
                OnPropertyChanged( nameof( SelectedMeetingRoom ) );
            }
        }

        public ObservableCollection<MeetingCenterModel> MeetingCenters { get; set; } = new ObservableCollection<MeetingCenterModel>( );
        private Dictionary<MeetingCenterModel, ObservableCollection<MeetingRoomModel>> _meetingRooms { get; set; } = new Dictionary<MeetingCenterModel, ObservableCollection<MeetingRoomModel>>( );

        public ObservableCollection<MeetingRoomModel> GetMeetingRooms( MeetingCenterModel meetingCenter )
        {
            if ( _meetingRooms.ContainsKey( meetingCenter ) )
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( string propertyName ) => PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}
