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
    public class NewsManager : IManager<News>
    {
        public News Create(News model)
        {
            using (var ctx = new OSGContext())
            {                
                ctx.News.Attach(model);
                var newsToReturn = ctx.News.Add(model);
                ctx.SaveChanges();
                return newsToReturn;
            }
        }

        public bool Delete(News model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> ReadAll()
        {
            throw new NotImplementedException();
        }

        public News ReadByID(int id)
        {
            throw new NotImplementedException();
        }

        public News Update(News model)
        {
            throw new NotImplementedException();
        }
    }
}
