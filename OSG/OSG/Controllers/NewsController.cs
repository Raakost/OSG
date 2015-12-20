using System.Linq;
using System.Web.Mvc;
using Gateway.DomainModel;
using Gateway.Facade;
using OSG.Models.ViewModel;

namespace OSG.Controllers
{
    public class NewsController : Controller
    {
        Facade facade = new Facade();
        // GET: News
        public ActionResult Index(int? newsId)
        {
            var newsIndex = new NewsIndex();
            newsIndex.Id = newsId;
            newsIndex.newsList = facade.GetNewsGateway().ReadAll().ToList();
            return View(newsIndex);
        }

        public ActionResult Options()
        {
            return View(facade.GetNewsGateway().ReadAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new News());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            facade.GetNewsGateway().Create(new News()
            {
                Id = news.Id,
                Description = news.Description,
                Picture = news.Picture,
                Date = news.Date,
                Title = news.Title
            });
            return RedirectToAction("Options", "News");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            News news = facade.GetNewsGateway().ReadById(id);
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            facade.GetNewsGateway().Update(news);
            return RedirectToAction("Options", "News");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            facade.GetNewsGateway().Delete(id);
            return RedirectToAction("Options", "News");
        }
    }
}