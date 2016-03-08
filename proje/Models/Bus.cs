using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class Bus
    {
       public virtual int busId { get; set; }
       public virtual string plate { get; set; }
       public virtual string busModel { get; set; }
       public virtual int maxBusPassenger {get; set;}
       public virtual bool state { get; set; }
       public virtual DateTime createdAt { get; set; }
    }

    public class BusMap : ClassMapping<Bus>
    {
        public BusMap()
        {
            Table("Bus");
            Id(x => x.busId, x => x.Generator(Generators.Identity));
            Property(x => x.plate, x => x.NotNullable(true));
            Property(x => x.busModel, x => x.NotNullable(true));
            Property(x => x.maxBusPassenger, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));
        }
    }
}
