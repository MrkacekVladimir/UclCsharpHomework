using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;
using System;
using System.ComponentModel;

namespace HomeWorkOne.Core.ViewModels
{
    public class ReservationViewModel : IReservation, INotifyPropertyChanged
    {
        public ReservationViewModel( IMeetingRoom room )
        {
            MeetingRoomCode = room.Code;
            MeetingCenterCode = room.MeetingCentreCode;
        }

        public ReservationViewModel( IMeetingRoom room, IReservation data ): this(room)
        {
            this.SetData( data );
        }


        private DateTime _from;
        public DateTime From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged( nameof( From ) );
            }
        }

        private DateTime _until;
        public DateTime Until
        {
            get { return _until; }
            set
            {
                _until = value;
                OnPropertyChanged( nameof( Until ) );
            }
        }

        private int _expectedPersonCount;
        public int ExpectedPersonCount
        {
            get { return _expectedPersonCount; }
            set
            {
                _expectedPersonCount = value;
                OnPropertyChanged( nameof( ExpectedPersonCount ) );
            }
        }

        private bool _isVideoConference;
        public bool IsVideoConference
        {
            get { return _isVideoConference; }
            set
            {
                _isVideoConference = value;
                OnPropertyChanged( nameof( IsVideoConference ) );
            }
        }

        private string _customer;
        public string Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged( nameof( Customer ) );
            }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set
            {
                _note = value;
                OnPropertyChanged( nameof( Note ) );
            }
        }

        public string MeetingCenterCode { get; set; }
        public string MeetingRoomCode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( string propertyName ) => PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}
