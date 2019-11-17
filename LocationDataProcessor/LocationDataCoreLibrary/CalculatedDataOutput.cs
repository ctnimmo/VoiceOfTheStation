using System;
using System.Collections.Generic;
using System.Text;

namespace LocationDataCoreLibrary
{
    public class CalculatedDataOutput : ICalculatedDataOutput
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Minute { get; set; }
        public string Second { get; set; }
        public string MilliSecond { get; set; }
        public string UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string NeigbourhoodSize { get; set; }

        public string AcceptableNeighbourhoodSize { get; set; }

        public string IsAcceptable { get; set; }
        public string IsHappyFace { get; set; }

    }

    public interface ICalculatedDataOutput
    {
        string Year { get; set; }
        string Month { get; set; }
        string Day { get; set; }
        string Hour { get; set; }
        string Minute { get; set; }
        string Second { get; set; }
        string MilliSecond { get; set; }
        string UserId { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        string NeigbourhoodSize { get; set; }
        string AcceptableNeighbourhoodSize { get; set; }

        string IsAcceptable { get; set; }
        string IsHappyFace { get; set; }
    }
}
