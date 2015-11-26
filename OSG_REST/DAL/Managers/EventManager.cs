using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;
using DAL.Managers.IManager;

namespace DAL.Managers
{
    public class EventManager : IManager<Event>
    {
        public Event Create(Event model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Event model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Event ReadByID(int id)
        {
            throw new NotImplementedException();
        }

        public Event Update(Event model)
        {
            throw new NotImplementedException();
        }
    }
}
