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
        public virtual int shiftTimeId { get; set; }
        public virtual DateTime departureTime { get; set; }
      
        public virtual Bus plate { get; set; }
        public virtual Driver driverId { get; set; }
        public virtual Line lineId { get; set; }
        public virtual DateTime stiftStart { get; set; }
        public virtual DateTime shiftEnd { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class ShiftTimeMap : ClassMapping<ShiftTime>
    {
        public ShiftTimeMap()
        {
            Table("ShiftTime");
            Id(x => x.shiftTimeId, x => x.Generator(Generators.Identity));
            Property(x => x.departureTime, x => x.NotNullable(true));
            Property(x => x.stiftStart, x => x.NotNullable(true));
            Property(x => x.shiftEnd, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));


            ManyToOne(x => x.driverId, x =>
            {
                x.Column("driverId");
                x.NotNullable(true);
                x.Lazy(LazyRelation.NoLazy);
            });


            ManyToOne(x => x.plate, x =>
            {
                x.Column("plate");
                x.NotNullable(true);
                x.Lazy(LazyRelation.NoLazy);
            });


            ManyToOne(x => x.lineId, x =>
            {
                x.Column("lineId");
                x.NotNullable(true);
                x.Lazy(LazyRelation.NoLazy);
            }); 
        }
    }

  public class ShifTimeService
    {
        ShiftTime message;
        public Object Get(ShiftTime shifTime)
        {// burda plaka ile sorgu attgında istegin bilgiler geliyolar stations dişinda onun içde rankinge sorgu atarsın
            Bus existPlate = Database.Session.QueryOver<Bus>().Where(x => x.plate == shifTime.plate.plate).SingleOrDefault();
            IEnumerable<ShiftTime> existShifTime = Database.Session.QueryOver<ShiftTime>().Where(x => x.plate.busId == existPlate.busId && ( x.stiftStart<= DateTime.Now && DateTime.Now<=x.shiftEnd)).OrderBy(y => y.createdAt).Desc.List();
            message = existShifTime.FirstOrDefault();
            Database.Session.Flush();
            Database.Session.Clear();
           
            
            return message;
        }
        Object mssg;
        //trigger kulanmak gerekecek sanırım state zamanı dolunca degiştiroyorsam 
        //bide burda 4 tane tarih var ben sorgulamayı yapaerken deparutretime kullanmadım 
        public Object Save(ShiftTime shifTime)
        {
            
            try
            {
                //otobus driver yada line state false uyarması gerek 
                shifTime.createdAt = DateTime.Now;
                shifTime.state = true;
                Database.Session.Save(shifTime);
            }
            catch(Exception e)
            {
                if (e.InnerException.Message != null)
                    mssg = e.InnerException.Message;
                else
                    mssg = e.Message;


            }
            return mssg;
        }
    }
}
