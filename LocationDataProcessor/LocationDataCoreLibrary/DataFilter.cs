using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDataCoreLibrary
{
   class DataFilter : IDataFilter
   {
        public LocationDataType FilterType { get; set; }
        public string Filter { get; set; }
   }
}
