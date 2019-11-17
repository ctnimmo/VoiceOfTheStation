using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoiceOfTheStation.API.Models
{
    public interface IPassengerLocation
    {
        string TimeStamp { get; set; }
        string userid { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        string connectiontype { get; set; }
        string devicelanguage { get; set; }
    }
}
