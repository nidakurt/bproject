using proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class LineController : ApiController
    {
        LineService lineService = new LineService();
        [HttpPost]
       public Object SaveOrUpdate(Line line)
        {
            return lineService.saveOrUpdate(line);
        }
        [HttpPost]
        public object getOrGetAll(Line line)
        {
            return lineService.getOrGetAll(line);
        }
    }
}
