using HomeWorkOne.Core.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkOne.Core.Services
{
    public interface IExportImportManager
    {
        void Export( string path, Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> dict );
        Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> Import( string path );
    }
}
