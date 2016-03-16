using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class DriverController :ApiController
    {
        DriverService driverService = new DriverService();
        [HttpPost]
        public Object SaveOrUpdate(Driver driver)
        {
            return driverService.saveOrUpdate(driver);
        }
        [HttpPost]
        public Object getOrGetAll(Driver driver)
        {
            return driverService.getOrGetAll(driver);
        }
    }
}