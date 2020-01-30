using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;
using System;
using System.ComponentModel;

namespace HomeWorkOne.Core.ViewModels
{
    public class MeetingRoomModel : IMeetingRoom, INotifyPropertyChanged
    {
        public MeetingRoomModel( )
        {

        }

        public MeetingRoomModel( IMeetingRoom data )
        {
            this.SetData( data );
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged( nameof(Name) );
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged( nameof(Code) );
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged( nameof(Description) );
            }
        }

        private int _capacity;
        public int Capacity
        {
            get { return _capacity; }
            set
            {
                _capacity = value;
                OnPropertyChanged( nameof( Description ) );
            }
        }

        private bool _allowsVideoConference;
        public bool AllowsVideoConference
        {
            get { return _allowsVideoConference; }
            set
            {
                _allowsVideoConference = value;
                OnPropertyChanged( nameof(AllowsVideoConference) );
            }
        }

        public string MeetingCentreCode { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( string propertyName ) => PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}
