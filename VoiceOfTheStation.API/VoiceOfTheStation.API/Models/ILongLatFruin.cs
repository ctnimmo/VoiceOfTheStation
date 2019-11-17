﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceOfTheStation.API.Models
{
    public interface ILongLatFruin
    {
        string Longitude { get; set; }
        string Latitude { get; set; }
        string Fruin { get; set; }
    }
}
