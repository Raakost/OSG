using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;
using DAL.Managers.IManager;

namespace DAL.Managers
{
    public class CommentManager : IManager<Comment>
    {
        public Comment Create(Comment model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Comment model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Comment ReadByID(int id)
        {
            throw new NotImplementedException();
        }

        public Comment Update(Comment model)
        {
            throw new NotImplementedException();
        }
    }
}
