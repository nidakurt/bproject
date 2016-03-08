using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class Station
    {
        public virtual int stationId { get; set; }
        public virtual string stationName { get; set; }
        public virtual string location { get; set; }
        public virtual string address { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class StationMap : ClassMapping<Station>
    {
        public StationMap()
        {
            Table("Station");
            Id(x => x.stationId, x => x.Generator(Generators.Identity));
            Property(x => x.stationName, x => x.NotNullable(true));
            Property(x => x.location, x => x.NotNullable(true));
            Property(x => x.address, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

            
        }
    }
}
