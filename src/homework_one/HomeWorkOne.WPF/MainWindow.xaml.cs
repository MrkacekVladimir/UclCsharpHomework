using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;
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

        public MainWindow( )
        {
            InitializeComponent( );

            DataContext = _viewModel;
            MeetingCentersDataGrid.ItemsSource = _viewModel.MeetingCenters;
        }

        #region Meeting Centers

        private void MeetingCentersDataGrid_SelectionChanged( object sender, System.Windows.Controls.SelectionChangedEventArgs e )
        {
            if ( e.AddedItems.Count > 0 )
            {
                if ( e.AddedItems[ 0 ] is MeetingCenterModel meetingCenter )
                {
                    _viewModel.SelectedMeetingCenter = meetingCenter;
                    MeetingRoomsDataGrid.ItemsSource = _viewModel.GetMeetingRooms( meetingCenter );
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
                _viewModel.MeetingCenters.Add( new MeetingCenterModel( values ) );
            }
        }

        private void MeetingCentersEditBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingCenter != null )
            {
                ManageMeetingCenterWindow window = new ManageMeetingCenterWindow( _viewModel.SelectedMeetingCenter );
                window.ShowDialog( );

                if ( window.DialogResult.HasValue && (bool)window.DialogResult )
                {
                    var values = window.GetMeetingCenterValues( );
                    _viewModel.SelectedMeetingCenter.SetData( values );
                }
            }
        }

        private void MeetingCentersDeleteBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingCenter != null )
            {
                var result = GetConfirmationResult( $"Are you sure you want to delete '{_viewModel.SelectedMeetingCenter.Name}' (code: {_viewModel.SelectedMeetingCenter.Code}) ?", "Delete Meeting Center" );
                if ( result )
                {
                    _viewModel.MeetingCenters.Remove( _viewModel.SelectedMeetingCenter );
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
                _viewModel.SelectedMeetingRoom = e.AddedItems[ 0 ] as MeetingRoomModel;
            }
        }

        private void MeetingRoomsAddBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingCenter != null )
            {
                ManageMeetingRoomWindow window = new ManageMeetingRoomWindow( );
                window.ShowDialog( );

                if ( window.DialogResult.HasValue && (bool)window.DialogResult )
                {
                    var values = window.GetMeetingRoomValues( );
                    _viewModel.GetMeetingRooms( _viewModel.SelectedMeetingCenter ).Add( new MeetingRoomModel( values ) );
                }
            }
        }

        private void MeetingRoomsEditBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingRoom != null )
            {
                ManageMeetingRoomWindow window = new ManageMeetingRoomWindow( _viewModel.SelectedMeetingRoom );
                window.ShowDialog( );

                if ( window.DialogResult.HasValue && (bool)window.DialogResult )
                {
                    var values = window.GetMeetingRoomValues( );
                    _viewModel.SelectedMeetingRoom.SetData( values );
                }
            }
        }

        private void MeetingRoomsDeleteBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingRoom != null )
            {
                var result = GetConfirmationResult( $"Are you sure you want to delete '{_viewModel.SelectedMeetingRoom.Name}' ?", "Delete Meeting Room" );
                if ( result )
                {
                    _viewModel.GetMeetingRooms( _viewModel.SelectedMeetingCenter ).Remove( _viewModel.SelectedMeetingRoom );
                }
            }
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
            if(saveDialog.ShowDialog() == true )
            {
                saveDialog.AddExtension = true;

            }
        }

        private void MenuItemImportBtn_Click( object sender, RoutedEventArgs e )
        {
            OpenFileDialog fileDialog = new OpenFileDialog( );
            if ( fileDialog.ShowDialog( ) == true )
            {

            }
        }
    }
}
