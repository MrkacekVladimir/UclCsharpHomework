using HomeWorkOne.Core.Entities.Definitions;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeWorkOne.Core.Services
{
    public class ExportImportManager
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
                    sw.WriteLine( $"{key.Name};{key.Code};{key.Description};" );

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
    }
}
