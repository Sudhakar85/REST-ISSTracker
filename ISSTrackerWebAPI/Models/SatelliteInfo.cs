using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTrackerWebAPI.Models
{
    public class SatelliteInfo
    {
        public string Name { get; set; }
        public string SatelliteNumber { get; set; }
        public double Elevation { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime Time { get; set; }
        public double Speed{ get; set; }
        public int MyProperty { get; set; }        
    }

    public class Satellite
    {
        public string Purpose { get; set; }
        public List<string> Name { get; set; }
        
    }
}