using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MvcApplication1.Controllers
{
    public class StationController : ApiController
    {
        StationService stationService = new StationService();
       [HttpPost]
       public Object SaveOrUpdate(Station station)
        {
            return stationService.saveOrUpdate(station);
        }
        [HttpPost]
        public object getOrGetAll(Station station)
        {
            return stationService.getOrGetAll(station);
        }

    }
}
