using HomeWorkOne.Core.Entities.Common;
using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.ViewModels;
using System.Windows;

namespace HomeWorkOne.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ManageMeetingCenterWindow.xaml
    /// </summary>
    public partial class ManageMeetingCenterWindow : Window
    {
        private readonly MeetingCenterModel _viewModel = new MeetingCenterModel( );

        public ManageMeetingCenterWindow( )
        {
            InitializeComponent( );
            DataContext = _viewModel;
        }

        public ManageMeetingCenterWindow( IMeetingCenter meetingCenter ) : this( )
        {
            _viewModel = new MeetingCenterModel( meetingCenter );
            DataContext = _viewModel;
        }

        public IMeetingCenter GetMeetingCenterValues( ) => _viewModel;

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
