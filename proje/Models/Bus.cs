using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;

namespace proje.Models
{
    public class Bus
    {
        public virtual int busId { get; set; }
        public virtual string plate { get; set; }
        public virtual string busModel { get; set; }
        public virtual int maxBusPessenger { get; set; }
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
            Property(x => x.maxBusPessenger, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(false));
            Property(x => x.createdAt, x => x.NotNullable(true));
        }
    }

    public class BusService
    {
        Bus newBus = new Bus();
        Object message;
       
        public Object saveOrUpdate(Bus bus)
            
        {  Bus existBus = Database.Session.Load<Bus>(bus.busId);
            
            if (existBus.busId==0)
            {
                bus.createdAt = System.DateTime.Now;
                bus.state = true;
                try
                  {
                    Database.Session.Save(bus);
                  }
                catch(Exception e)
                 {
                    message = e.InnerException.Message;
                 }
            }
            else
            {
               
                newBus = bus;
                newBus.createdAt = System.DateTime.Now;
                newBus.state = true;
                if (bus.busModel == null || bus.maxBusPessenger == 0 || bus.plate == null)
                {
                    
                    if (bus.busModel  == null)
                        newBus.busModel = existBus.busModel;
                    if (bus.maxBusPessenger == 0)
                        newBus.maxBusPessenger = existBus.maxBusPessenger;
                    if (bus.plate == null)
                        newBus.plate = existBus.plate;   

                }
                try
                {
                    Database.Session.Clear();
                    Database.Session.Update(newBus);
                    Database.Session.Flush();
                    
                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            return message;
        }


        //public Object Update(Bus s)
        //{
        //    message = "Update is successfull";


        //    Bus bus = Database.Session.Load<Bus>(s.busId);
        //    if (bus == null)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        if (bus.plate == null || bus.maxBusPessenger == 0 || bus.busModel == null)
        //        {
        //            bus.state = true;
        //            bus.createdAt = DateTime.UtcNow;
        //            Database.Session.Load<Bus>(s);
        //        }
        //        else
        //        {
        //            bus.plate = s.plate;
        //            bus.maxBusPessenger = s.maxBusPessenger;
        //            bus.busModel = s.busModel;
        //            bus.state = true;
        //            bus.createdAt = DateTime.UtcNow;

        //        }
        //        try
        //        {
        //            Database.Session.Flush();
        //            Database.Session.Clear();
        //            Database.Session.Update(bus);

        //        }
        //        catch (Exception e)
        //        {
        //            message = e;
        //        }
        //    }
        //    return message;
        //}
         
        public Object getOrGetAll(Bus bus)
        {
            if(bus.plate==null)
            {
               message= Database.Session.QueryOver<Bus>().Where(x => x.state == true).List();
            }
            else
            {

                message = Database.Session.QueryOver<Bus>().Where(x => x.plate == bus.plate && x.state == true).List();
            }
            return message;
        }
     
    }
}
