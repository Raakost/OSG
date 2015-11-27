using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;
using DAL.Managers.IManager;

namespace DAL.Managers
{
    public class TrainerManager : IManager<Trainer>
    {
        public Trainer Create(Trainer model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Trainer model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trainer> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Trainer ReadByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Trainer Update(Trainer model)
        {
            throw new NotImplementedException();
        }
    }
}
