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
            using (var ctx = new OSGContext())
            {
                var newsToDelete = ctx.News.FirstOrDefault(news => news.Id == model.Id);
                if (newsToDelete != null)
                {
                    ctx.News.Remove(newsToDelete);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<News> ReadAll(int amound = 10)
        {
            using (var ctx = new OSGContext())
            {
                return ctx.News.ToList();
            }
        }


        public News ReadByID(int Id)
        {
            using (var ctx = new OSGContext())
            {
                return ctx.News.FirstOrDefault(news => news.Id == Id);
            }
        }

        public News Update(News model)
        {
            using (var ctx = new OSGContext())
            {
                var newsToUpdate = ctx.News.FirstOrDefault(news => news.Id == model.Id);
                if (newsToUpdate != null)
                {
                    newsToUpdate.Date = model.Date;
                    newsToUpdate.Description = model.Description;
                    newsToUpdate.Picture = model.Picture;
                    newsToUpdate.Title = model.Title;
                    ctx.SaveChanges();
                    return newsToUpdate;
                }
                return model;
            }
        }
    }
}
