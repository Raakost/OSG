using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gateway.DomainModel;
using Gateway.Facade;
using OSG.Models;

namespace OSG.Controllers
{
    public class NewsController : Controller
    {
        Facade facade = new Facade();
        // GET: News
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(News news)
        {
            facade.GetNewsGateway().Add(new News()
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
        public ActionResult Edit(News news)
        {
            facade.GetNewsGateway().Update(news);
            return RedirectToAction("Options", "News");
        }
    }
}