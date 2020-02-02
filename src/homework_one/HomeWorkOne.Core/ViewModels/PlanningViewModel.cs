using HomeWorkOne.Core.Entities.Definitions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeWorkOne.Core.ViewModels
{
    public class PlanningViewModel : INotifyPropertyChanged
    {
        public IMeetingCenter SelectedMeetingCenter { get; set; }
        public IMeetingRoom SelectedMeetingRoom { get; set; }
        public IReservation SelectedReservation { get; set; }
        public DateTime SelectedDate { get; set; }

        public ObservableCollection<IMeetingRoom> MeetingRooms { get; set; } = new ObservableCollection<IMeetingRoom>( );
        public ObservableCollection<IMeetingCenter> MeetingCenters { get; set; } = new ObservableCollection<IMeetingCenter>( );
        public ObservableCollection<IReservation> Reservations { get; set; } = new ObservableCollection<IReservation>( );
                

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( string propertyName ) => PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}
