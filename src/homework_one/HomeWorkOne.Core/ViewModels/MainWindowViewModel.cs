using HomeWorkOne.Core.Entities.Definitions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

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

        public Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> GetData( )
        {
            var dict = new Dictionary<IMeetingCenter, ICollection<IMeetingRoom>>( );
            foreach ( var center in MeetingCenters )
            {
                var roomList = new List<IMeetingRoom>( );
                roomList.AddRange( GetMeetingRooms(center) );

                dict[ center ] = roomList;
            }

            return dict;
        }

        public void SetData( Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> dict )
        {
            MeetingCenters = new ObservableCollection<MeetingCenterModel>( );
            _meetingRooms = new Dictionary<MeetingCenterModel, ObservableCollection<MeetingRoomModel>>( );

            foreach ( var center in dict.Keys )
            {
                var centerModel = new MeetingCenterModel( center );                
                MeetingCenters.Add( centerModel );

                var roomCollection = new ObservableCollection<MeetingRoomModel>( );

                var rooms = dict[ center ];
                foreach ( var room in rooms )
                {
                    var roomModel = new MeetingRoomModel( room );
                    roomCollection.Add( roomModel );
                }

                _meetingRooms[ centerModel ] = roomCollection;
            }

            OnPropertyChanged( nameof( MeetingCenters ) );
            OnPropertyChanged( nameof( _meetingRooms ) );
        }
    }
}
