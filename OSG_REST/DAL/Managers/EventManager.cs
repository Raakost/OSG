using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.DomainModel;
using DAL.Managers.IManager;

namespace DAL.Managers
{
    public class EventManager : IManager<Event>
    {
        public Event Create(Event model)
        {
            using (var ctx = new OSGContext())
            {
                ctx.Event.Attach(model);
                var eventToReturn = ctx.Event.Add(model);
                ctx.SaveChanges();
                return eventToReturn;
            }
        }

        public bool Delete(Event model)
        {
            using (var ctx = new OSGContext())
            {
                var eventToDelete = ctx.Event.FirstOrDefault(_event => _event.Id == model.Id);
                if (eventToDelete != null)
                {
                    ctx.Event.Remove(eventToDelete);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<Event> ReadAll()
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Event.ToList();
            }
        }

        public Event ReadByID(int Id)
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Event.FirstOrDefault(_event => _event.Id == Id);
            }
        }

        public Event Update(Event model)
        {
            using (var ctx = new OSGContext())
            {
                var eventToUpdate = ctx.Event.FirstOrDefault(_event => _event.Id == model.Id);
                if (eventToUpdate != null)
                {
                    eventToUpdate.Date = model.Date;
                    eventToUpdate.Description = model.Description;
                    eventToUpdate.Title = model.Title;
                    eventToUpdate.Trainers = model.Trainers.ToList();
                    return eventToUpdate;
                }
            }
            return model;
        }
    }
}
