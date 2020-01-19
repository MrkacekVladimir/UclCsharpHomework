using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;
using System.ComponentModel;

namespace HomeWorkOne.Core.ViewModels
{
    public class MeetingCenterModel : IMeetingCenter, INotifyPropertyChanged
    {
        public MeetingCenterModel( )
        {

        }

        public MeetingCenterModel( IMeetingCenter data )
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
                OnPropertyChanged( nameof( Name ) );
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged( nameof( Code ) );
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged( nameof( Description ) );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged( string propertyName ) => PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}
