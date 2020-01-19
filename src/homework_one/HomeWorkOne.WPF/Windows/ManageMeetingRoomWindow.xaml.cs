using HomeWorkOne.Core.Entities.Common;
using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.ViewModels;
using System.Windows;

namespace HomeWorkOne.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ManageMeetingRoomWindow.xaml
    /// </summary>
    public partial class ManageMeetingRoomWindow : Window
    {
        private readonly MeetingRoomModel _viewModel = new MeetingRoomModel( );

        public ManageMeetingRoomWindow( )
        {
            InitializeComponent( );
            DataContext = _viewModel;
        }

        public ManageMeetingRoomWindow( IMeetingRoom meetingRoom ): this()
        {
            _viewModel = new MeetingRoomModel( meetingRoom );
            DataContext = _viewModel;
        }

        public IMeetingRoom GetMeetingRoomValues( ) => _viewModel;

        private void SaveBtn_Click( object sender, RoutedEventArgs e )
        {
            DialogResult = true;
            Close( );
        }

        private void CancelBtn_Click( object sender, RoutedEventArgs e )
        {
            DialogResult = false;
            Close( );
        }
    }
}
