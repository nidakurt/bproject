using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class ShiftTime
    {
        public virtual int stiftTimeId { get; set; }
        public virtual DateTime departureTime { get; set; }
        public virtual Bus plate { get; set; }
        public virtual Driver driverId { get; set; }
        public virtual Line lineId { get; set; }
        public virtual DateTime shiftStart { get; set; }
        public virtual DateTime shiftEnd { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class ShiftTimeMap : ClassMapping<ShiftTime>
    {
        public ShiftTimeMap()
        {
            Table("ShiftTime");
            Id(x => x.stiftTimeId, x => x.Generator(Generators.Identity));
            Property(x => x.departureTime, x => x.NotNullable(true));
            Property(x => x.shiftStart, x => x.NotNullable(true));
            Property(x => x.shiftEnd, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));


            ManyToOne(x => x.driverId, x =>
            {
                x.Column("driverId");
                x.NotNullable(true);
            });


            ManyToOne(x => x.plate, x =>
            {
                x.Column("plate");
                x.NotNullable(true);
            });


            ManyToOne(x => x.lineId, x =>
            {
                x.Column("lineId");
                x.NotNullable(true);
            }); 
        }
    }
}
