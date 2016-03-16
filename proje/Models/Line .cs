using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Models
{
   public class Line
    {
        public virtual int lineId { get; set; }
        public virtual string lineName { get; set; }
        public virtual bool state { get; set; }
        public virtual DateTime createdAt { get; set; }
    }

    public class LineMap : ClassMapping<Line>
    {
        public LineMap()
        {
            Table("Line");
            Id(x => x.lineId, x => x.Generator(Generators.Identity));
            Property(x => x.lineName, x => x.NotNullable(true));
            Property(x => x.state, x => x.NotNullable(true));
            Property(x => x.createdAt, x => x.NotNullable(true));
        }
    }

    public class LineService
    {
        Line newLine = new Line();
        Object message;

        public Object saveOrUpdate(Line line)
        {
            Line existLine = Database.Session.Load<Line>(line.lineId);
            if (existLine.lineId == 0)
            {
                line.createdAt = System.DateTime.Now;
                line.state = true;
                try
                {
                    Database.Session.Save(line);
                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            else
            {
                newLine = line;
                newLine.createdAt = System.DateTime.Now;
                newLine.state = true;
                try
                {
                    Database.Session.Clear();
                    Database.Session.Flush();
                }
                catch (Exception e)
                {
                    message = e.InnerException.Message;
                }
            }
            return message;
        }
        
        public Object getOrGetAll(Line line)
        {
            if(line.lineId==0)
            {
                message = Database.Session.QueryOver<Line>().Where(x => x.state == true).List();
            }
            else
            {
                message = Database.Session.QueryOver<Line>().Where(x => x.lineId == line.lineId && x.state == true).List();
            }
            return message;
        }
       }
    }

