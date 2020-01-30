using HomeWorkOne.Core.Entities.Common;
using HomeWorkOne.Core.Entities.Definitions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeWorkOne.Core.Services
{
    public class CsvExportImportManager: IExportImportManager
    {
        private const string CENTERS_HEADER = "MEETING_CENTRES";
        private const string ROOMS_HEADER = "MEETING_ROOMS";

        public void Export( string path, Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> dict )
        {
            var exists = File.Exists( path );
            if ( exists )
            {
                File.Delete( path );
            }

            using ( StreamWriter sw = new StreamWriter( path ) )
            {
                sw.WriteLine( CENTERS_HEADER );

                StringBuilder roomsBuilder = new StringBuilder( );

                foreach ( var key in dict.Keys )
                {
                    sw.WriteLine( $"{key.Name};{key.Code};{key.Description}" );

                    var values = dict[ key ];
                    foreach ( var value in values )
                    {
                        string allowsVideo = value.AllowsVideoConference ? "YES" : "NO";

                        roomsBuilder.AppendLine( $"{value.Name};{value.Code};{value.Description};{value.Capacity};{allowsVideo};{key.Code}" );
                    }
                }

                sw.WriteLine( ROOMS_HEADER );
                sw.WriteLine( roomsBuilder.ToString( ) );
            }
        }

        public Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> Import( string path )
        {
            var dict = new Dictionary<IMeetingCenter, ICollection<IMeetingRoom>>( );
            var exists = File.Exists( path );
            using ( StreamReader sr = new StreamReader( path ) )
            {
                bool isCenter = false;
                while ( !sr.EndOfStream )
                {
                    var line = sr.ReadLine( );
                    if ( line == CENTERS_HEADER )
                    {
                        isCenter = true;
                        continue;
                    }
                    else if ( line == ROOMS_HEADER )
                    {
                        isCenter = false;
                        continue;
                    }

                    string[] parts = line.Split( ';' );
                    if ( isCenter )
                    {
                        var meetingCenter = GetMeetingCenterFromArray( parts );
                        if(meetingCenter != null )
                        {
                            dict.Add( meetingCenter, new List<IMeetingRoom>( ) );
                        }                        
                    }
                    else
                    {
                        var meetingRoom = GetMeetingRoomFromArray( parts );
                        if(meetingRoom != null )
                        {
                            var meetingCenter = dict.Keys.FirstOrDefault( mc => mc.Code == meetingRoom.MeetingCentreCode );
                            if ( meetingCenter != null )
                            {
                                var roomCollection = dict[ meetingCenter ];
                                roomCollection.Add( meetingRoom );
                            }
                        }
                    }
                }
                return dict;
            }
        }

        private IMeetingCenter GetMeetingCenterFromArray( string[] parts )
        {
            IMeetingCenter meetingCenter = null;
            if (parts.Length == 3 )
            {
                string name = parts[ 0 ];
                string code = parts[ 1 ];
                string description = parts[ 2 ];

                meetingCenter = new MeetingCenterData
                {
                    Name = name,
                    Code = code,
                    Description = description
                };
            }

            return meetingCenter;
        }

        private IMeetingRoom GetMeetingRoomFromArray( string[] parts )
        {
            IMeetingRoom meetingRoom = null;
            if ( parts.Length == 6 )
            {
                string name = parts[ 0 ];
                string code = parts[ 1 ];
                string description = parts[ 2 ];
                int capacity = int.Parse( parts[ 3 ] );
                bool allowsVideo = parts[ 4 ] == "YES" ? true : false;
                string meetingCenterCode = parts[ 5 ];

                meetingRoom = new MeetingRoomData
                {
                    Name = name,
                    Code = code,
                    Description = description,
                    Capacity = capacity,
                    AllowsVideoConference = allowsVideo,
                    MeetingCentreCode = meetingCenterCode
                };
            }

            return meetingRoom;
        }
    }
}
