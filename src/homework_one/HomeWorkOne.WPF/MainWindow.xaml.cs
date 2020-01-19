using HomeWorkOne.Core.Entities;
using HomeWorkOne.Core.Entities.Common;
using HomeWorkOne.Core.Entities.Definitions;
using HomeWorkOne.Core.Entities.Extensions;
using HomeWorkOne.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;

namespace HomeWorkOne.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow( )
        {
            InitializeComponent( );

            _viewModel = new MainWindowViewModel( );

            MeetingCentersDataGrid.ItemsSource = _viewModel.MeetingCenters;            
        }

        #region Meeting Centers

        private void MeetingCentersDataGrid_SelectionChanged( object sender, System.Windows.Controls.SelectionChangedEventArgs e )
        {
            if ( e.AddedItems.Count > 0 )
            {
                 if(e.AddedItems[ 0 ] is MeetingCenterModel meetingCenter )
                {
                    _viewModel.SelectedMeetingCentre = meetingCenter;
                    MeetingRoomsDataGrid.ItemsSource = _viewModel.GetMeetingRooms(meetingCenter);
                }                
            }
        }

        private void MeetingCentersAddBtn_Click( object sender, RoutedEventArgs e )
        {
            var values = GetValuesForMeetingCenter( );

            _viewModel.MeetingCenters.Add( new MeetingCenterModel( values ) );
        }

        private void MeetingCentersEditBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingCentre != null )
            {
                var values = GetValuesForMeetingCenter( );
                _viewModel.SelectedMeetingCentre.SetData( values );
            }
        }

        private void MeetingCentersDeleteBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingCentre != null )
            {
                var result = GetConfirmationResult( $"Are you sure you want to delete '{_viewModel.SelectedMeetingCentre.Name}' (code: {_viewModel.SelectedMeetingCentre.Code}) ?", "Delete Meeting Center" );
                if ( result )
                {
                    _viewModel.MeetingCenters.Remove( _viewModel.SelectedMeetingCentre );
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
            var values = GetValuesForMeetingRoom( );

            _viewModel.GetMeetingRooms(_viewModel.SelectedMeetingCentre).Add( new MeetingRoomModel( values ) );
        }

        private void MeetingRoomsEditBtn_Click( object sender, RoutedEventArgs e )
        {
            if(_viewModel.SelectedMeetingRoom != null)
            {
                var values = GetValuesForMeetingRoom( );
                _viewModel.SelectedMeetingRoom.SetData( values );
            }
        }

        private void MeetingRoomsDeleteBtn_Click( object sender, RoutedEventArgs e )
        {
            if ( _viewModel.SelectedMeetingRoom != null )
            {
                var result = GetConfirmationResult( $"Are you sure you want to delete '{_viewModel.SelectedMeetingRoom.Name}' ?", "Delete Meeting Room" );
                if ( result )
                {
                    _viewModel.GetMeetingRooms( _viewModel.SelectedMeetingCentre ).Remove( _viewModel.SelectedMeetingRoom );
                }                
            }
        }

        #endregion

        private bool GetConfirmationResult( string text, string title )
        {
            var result = MessageBox.Show( text, title, MessageBoxButton.YesNo );
            return result == MessageBoxResult.Yes;
        }

        private IMeetingCenter GetValuesForMeetingCenter( )
        {
            var data = new MeetingCenterData( );

            data.Name = MeetingCenterNameInput.Text;
            data.Code = MeetingCenterCodeInput.Text;
            data.Description = MeetingCenterDescriptionInput.Text;            

            return data;
        }

        private IMeetingRoom GetValuesForMeetingRoom( )
        {
            var data = new MeetingRoomData( );

            data.Name = MeetingRoomNameInput.Text;
            data.Code = MeetingRoomCodeInput.Text;
            data.Description = MeetingRoomDescriptionInput.Text;
            data.AllowsVideoConference = MeetingRoomAllowsVideoInput.IsChecked.Value;

            return data;
        }
    }
}
