using System;
using System.Collections.Generic;
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
            EventTrainers viewModel = new EventTrainers()
            {
                Trainers = facade.GetTrainerGateway().ReadAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event anEvent, List<int> SelectedIDs)
        {
            var trainerList = new List<Trainer>();
            SelectedIDs.ForEach(id => trainerList.Add(new Trainer() { Id = id }));

            facade.GetEventGateway().Create(new Event()
            {
                Id = anEvent.Id,
                Date = anEvent.Date,
                Title = anEvent.Title,
                Description = anEvent.Description,
                Trainers = trainerList
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
        [ValidateAntiForgeryToken]
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