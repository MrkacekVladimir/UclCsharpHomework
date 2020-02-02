using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.ViewModels;
using System.Windows;

namespace HomeWorkOne.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ManageReservationWindow.xaml
    /// </summary>
    public partial class ManageReservationWindow : Window
    {
        private readonly ReservationViewModel _viewModel;

        public ManageReservationWindow( IMeetingRoom meetingRoom )
        {
            InitializeComponent( );
            _viewModel = new ReservationViewModel( meetingRoom );
            DataContext = _viewModel;
        }

        public IReservation GetReservationValues => _viewModel;

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
