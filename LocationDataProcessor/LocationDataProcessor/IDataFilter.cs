﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDataProcessor
{
    public interface IDataFilter
    {
        LocationDataType FilterType { get; set; }
        string Filter { get; set; }
    }
}
