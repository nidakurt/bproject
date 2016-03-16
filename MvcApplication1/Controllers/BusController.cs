using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class BusController : ApiController
    { BusService busService = new BusService();
        [HttpPost]
        public Object SaveOrUpdate(Bus bus)
        {
            return busService.saveOrUpdate(bus);
        }
        [HttpPost]
        public Object getOrGetAll(Bus bus)
        {
            return busService.getOrGetAll(bus);
        }
    }
}