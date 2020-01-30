using System;
using System.Collections.Generic;
using System.Text;
using HomeWorkOne.Core.Entities.Definitions;

namespace HomeWorkOne.Core.Services
{
    public class XmlExportImportManager : IExportImportManager
    {
        public void Export( string path, Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> dict )
        {
            //V případě reálné aplikace by se sem doplnila implementace, abychom splňovali Liskov Substitution Principle ze SOLIDu
            throw new NotImplementedException( );
        }

        public Dictionary<IMeetingCenter, ICollection<IMeetingRoom>> Import( string path )
        {
            //V případě reálné aplikace by se sem doplnila implementace, abychom splňovali Liskov Substitution Principle ze SOLIDu
            throw new NotImplementedException( );
        }
    }
}
