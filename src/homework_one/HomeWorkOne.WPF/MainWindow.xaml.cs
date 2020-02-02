using HomeWorkOne.Core.Entities.Extensions;
using HomeWorkOne.Core.Services;
using HomeWorkOne.Core.ViewModels;
using HomeWorkOne.WPF.Windows;
using Microsoft.Win32;
using System.Windows;

namespace HomeWorkOne.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel = new MainWindowViewModel( );
        private readonly IExportImportManager _exportImportManager = new CsvExportImportManager( );

        public MainWindow( )
        {
            InitializeComponent( );

            DataContext = _viewModel;
            MeetingCentersDataGrid.ItemsSource = _viewModel.CenterOverview.MeetingCenters;
        }

        #region Meeting Centers

        private void MeetingCentersDataGrid_SelectionChanged( object sender, System.Windows.Controls.SelectionChangedEventArgs e )
        {
            if ( e.AddedItems.Count > 0 )
            {
                if ( e.AddedItems[ 0 ] is MeetingCenterModel meetingCenter )
                {
                    _viewModel.CenterOverview.SelectedMeetingCenter = meetingCenter;
                    MeetingRoomsDataGrid.ItemsSource = _viewModel.CenterOverview.GetMeetingRooms( meetingCenter );
                }
            }
        }

        private void MeetingCentersAddBtn_Click( object sender, RoutedEventArgs e )
        {
            ManageMeetingCenterWindow window = new ManageMeetingCenterWindow( );
            window.ShowDialog( );

            if ( window.DialogResult.HasValue && (bool)window.DialogResult )
            {
                var values = window.GetMeetingCenterValues( );
                _viewModel.CenterOverview.MeetingCenters.Add( new MeetingCenterModel( values ) );
            }
        }

        private void MeetingCentersEditBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.CenterOverview.SelectedMeetingCenter != null )
            {
                ManageMeetingCenterWindow window = new ManageMeetingCenterWindow( _viewModel.CenterOverview.SelectedMeetingCenter );
                window.ShowDialog( );

                if ( window.DialogResult.HasValue && (bool)window.DialogResult )
                {
                    var values = window.GetMeetingCenterValues( );
                    _viewModel.CenterOverview.SelectedMeetingCenter.SetData( values );
                }
            }
        }

        private void MeetingCentersDeleteBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.CenterOverview.SelectedMeetingCenter != null )
            {
                var result = GetConfirmationResult( $"Are you sure you want to delete '{_viewModel.CenterOverview.SelectedMeetingCenter.Name}' (code: {_viewModel.CenterOverview.SelectedMeetingCenter.Code}) ?", "Delete Meeting Center" );
                if ( result )
                {
                    _viewModel.CenterOverview.MeetingCenters.Remove( _viewModel.CenterOverview.SelectedMeetingCenter );
                    MeetingRoomsDataGrid.ItemsSource = null;
                }
            }
        }

        #endregion

        #region Meeting Rooms

        private void MeetingRoomsDataGrid_SelectionChanged( object sender, System.Windows.Controls.SelectionChangedEventArgs e )
        {
            if ( e.AddedItems.Count > 0 )
            {
                _viewModel.CenterOverview.SelectedMeetingRoom = e.AddedItems[ 0 ] as MeetingRoomModel;
            }
        }

        private void MeetingRoomsAddBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.CenterOverview.SelectedMeetingCenter != null )
            {
                ManageMeetingRoomWindow window = new ManageMeetingRoomWindow( );
                window.ShowDialog( );

                if ( window.DialogResult.HasValue && (bool)window.DialogResult )
                {
                    var values = window.GetMeetingRoomValues( );
                    _viewModel.CenterOverview.GetMeetingRooms( _viewModel.CenterOverview.SelectedMeetingCenter ).Add( new MeetingRoomModel( values ) );
                }
            }
        }

        private void MeetingRoomsEditBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.CenterOverview.SelectedMeetingRoom != null )
            {
                ManageMeetingRoomWindow window = new ManageMeetingRoomWindow( _viewModel.CenterOverview.SelectedMeetingRoom );
                window.ShowDialog( );

                if ( window.DialogResult.HasValue && (bool)window.DialogResult )
                {
                    var values = window.GetMeetingRoomValues( );
                    _viewModel.CenterOverview.SelectedMeetingRoom.SetData( values );
                }
            }
        }

        private void MeetingRoomsDeleteBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.CenterOverview.SelectedMeetingRoom != null )
            {
                var result = GetConfirmationResult( $"Are you sure you want to delete '{_viewModel.CenterOverview.SelectedMeetingRoom.Name}' ?", "Delete Meeting Room" );
                if ( result )
                {
                    _viewModel.CenterOverview.GetMeetingRooms( _viewModel.CenterOverview.SelectedMeetingCenter ).Remove( _viewModel.CenterOverview.SelectedMeetingRoom );
                }
            }
        }

        #endregion

        #region Reservations

        private void ReservationsAddBtn_Click( object sender, RoutedEventArgs e )
        {

        }

        private void ReservationsEditBtn_Click( object sender, RoutedEventArgs e )
        {

        }

        private void ReservationsDeleteBtn_Click( object sender, RoutedEventArgs e )
        {

        }

        #endregion

        private bool GetConfirmationResult( string text, string title )
        {
            var result = MessageBox.Show( text, title, MessageBoxButton.YesNo );
            return result == MessageBoxResult.Yes;
        }

        private void MenuItemExportBtn_Click( object sender, RoutedEventArgs e )
        {
            SaveFileDialog saveDialog = new SaveFileDialog( );
            saveDialog.DefaultExt = "csv";
            if(saveDialog.ShowDialog() == true )
            {
                saveDialog.AddExtension = true;
                var fileName = saveDialog.FileName;

                var data = _viewModel.CenterOverview.GetData( );

                _exportImportManager.Export( fileName, data );
            }
        }

        private void MenuItemImportBtn_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog fileDialog = new OpenFileDialog( );
            if ( fileDialog.ShowDialog( ) == true )
            {
                var fileName = fileDialog.FileName;
                var data = _exportImportManager.Import( fileName );

                _viewModel.CenterOverview.SetData( data );                
            }
        }
    }
}
