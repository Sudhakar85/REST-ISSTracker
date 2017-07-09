using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSTrackerWebAPI.Interface
{
    public interface INord
    {
        List<Models.Satellite> GetAllSatellite();
        List<string> GetAllSatellite(string purpose);
    }
}