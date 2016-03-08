using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
     public class BusLocation
    {
        public virtual int busLocationId { get; set; }
        public virtual string busLocation { get; set; }
        public virtual Bus busId { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class BusLocationMap : ClassMapping<BusLocation>
    {
        public BusLocationMap()
        {
            Table("BusLocation");
            Id(x => x.busLocationId, x => x.Generator(Generators.Identity));
            Property(x => x.busLocation, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

            ManyToOne(x => x.busId, x =>
            {
                x.Column("busId");
                x.NotNullable(true);
            }); 


        }
    }
}
