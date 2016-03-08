using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class Driver
    {
        public virtual int driverId { get; set; }
        public virtual string nameSurname { get; set; }
        public virtual int picture { get; set; }
        public virtual int tc { get; set; }
        public virtual DateTime birthday { get; set; }
        public virtual string bloodGroup { get; set; }
        public virtual string phone { get; set; }
        public virtual string address { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class DriverMap : ClassMapping<Driver>
    {
        public DriverMap()
        {
            Table("Driver");
            Id(x => x.driverId, x => x.Generator(Generators.Identity));
            Property(x => x.nameSurname, x => x.NotNullable(true));
            Property(x => x.picture, x => x.NotNullable(true));
            Property(x => x.tc, x => x.NotNullable(true));
            Property(x => x.birthday, x => x.NotNullable(true));
            Property(x => x.bloodGroup, x => x.NotNullable(true));
            Property(x => x.phone, x => x.NotNullable(true));
            Property(x => x.address, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));

        }
    }
}
