using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ISSTrackerWebAPI.Interface;

namespace ISSTrackerWebAPI.Controllers
{
    public class SatelliteController : ApiController
    {
        INord NordProvider;
        public SatelliteController(INord provider)
        {
            NordProvider = provider;
        }

        [HttpGet]
        [Route("Satellite/All")]
        public HttpResponseMessage GetAllSatellite()
        {
            List<Models.Satellite> allSystems = NordProvider.GetAllSatellite();

            if (allSystems.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, allSystems);
                
        }


        [HttpGet]
        [Route("Satellite/ByCategory/{purpose}")]
        public IHttpActionResult GetAllSatelliteByPurpose(string purpose)
        {
            List<string> nameList = NordProvider.GetAllSatellite(purpose);

            if (nameList.Count == 0)
                return NotFound();

            return Json(nameList);
        }




    }
}
