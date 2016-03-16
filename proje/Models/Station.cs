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


    public class StationService
    {
        Station newStation = new Station();
        Object message;
        public Object saveOrUpdate(Station station)
        {
            Station existStation = Database.Session.Load<Station>(station.stationId);
            if (existStation.stationId == 0)
            {
                station.createdAt = System.DateTime.Now;
                station.state = true;
                try
                {
                    Database.Session.Save(station);
                }
                catch(Exception e)
                {
                    message = e.InnerException.Message;           
                }
            }
            else
            {
                newStation = station;
                newStation.createdAt = System.DateTime.Now;
                newStation.state = true;
                if (station.location == null || station.address == null)
                {
                    if (station.location == null)
                        newStation.location = existStation.location;
                    if (station.address == null)
                        newStation.address = existStation.address;
                }
                try
                {
                    Database.Session.Clear();
                    Database.Session.Update(newStation);
                    Database.Session.Flush();
                }
                catch(Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            return message;
        }
        public Object getOrGetAll(Station station)
        {
            if (station.stationId == null)
            {
                message = Database.Session.QueryOver<Station>().Where(x => x.state == true).List();
            }
            else
            {
                message = Database.Session.QueryOver<Station>().Where(x => x.stationId == station.stationId && x.state == true).List();
            }
            return message;
        }
    }
}
