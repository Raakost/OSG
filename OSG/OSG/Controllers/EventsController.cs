using System;
using System.Web.Mvc;
using Gateway.DomainModel;
using Gateway.Facade;
using OSG.Models.ViewModel;

namespace OSG.Controllers
{
    public class EventsController : Controller
    {
        Facade facade = new Facade();

        // GET: Events
        public ActionResult Index(DateTime? month)
        {
            if (!month.HasValue)
            {
                month = DateTime.Now;
            }
            var ec = new EventCalendar();
            ec.Month = month.Value;
            ec.Events = facade.GetEventGateway().ReadByMonth(month.Value);
            return View(ec);
        }

        public ActionResult Options()
        {
            return View(facade.GetEventGateway().ReadAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Event());
        }

        [HttpPost]
        public ActionResult Create(Event anEvent)
        {
            facade.GetEventGateway().Create(new Event()
            {
                Id = anEvent.Id,
                Date = anEvent.Date,
                Title = anEvent.Title,
                Description = anEvent.Description
            });
            return RedirectToAction("Options", "Events");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Event anEvent = facade.GetEventGateway().ReadById(id);
            return View(anEvent);
        }

        [HttpPost]
        public ActionResult Edit(Event anEvent)
        {
            facade.GetEventGateway().Update(anEvent);
            return RedirectToAction("Options", "Events");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            facade.GetEventGateway().Delete(id);
            return RedirectToAction("Options", "Events");
        }
    }
}