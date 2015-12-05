using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gateway.DomainModel;
using Gateway.Facade;
using OSG.Models.ViewModel;

namespace OSG.Controllers
{
    public class EventsController : Controller
    {
        List<Event> events = new List<Event>();
        Facade facade = new Facade();

        public EventsController()
        {
            events.Add(new Event()
            {
                Id = 1,
                Title = "First Event",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec a ex hendrerit, tincidunt risus porttitor, imperdiet lacus. Curabitur sem lacus, pulvinar eu vehicula in, dignissim ac lacus. Donec porttitor lobortis erat. Sed lacinia vitae est ut vehicula. Integer sit amet turpis eu enim lacinia tincidunt ut in nisi. Vivamus ultrices consequat magna eu rhoncus. Proin et hendrerit nibh.",
                Date = new DateTime(2015, 12, 02)
            });
            events.Add(new Event()
            {
                Id = 2,
                Title = "Second Event",
                Description = "This is the first event, EVER!!",
                Date = new DateTime(2015, 12, 02)
            });
            events.Add(new Event()
            {
                Id = 3,
                Title = "ThirdEvent",
                Description = "This is the first event, EVER!!",
                Date = new DateTime(2015, 12, 04)
            });
            events.Add(new Event()
            {
                Id = 4,
                Title = "ThirdEvent",
                Description = "This is the first event, EVER!!",
                Date = new DateTime(2015, 12, 04)
            });
            events.Add(new Event()
            {
                Id = 5,
                Title = "ThirdEvent",
                Description = "This is the first event, EVER!!",
                Date = new DateTime(2015, 12, 04)
            });
            events.Add(new Event()
            {
                Id = 6,
                Title = "ThirdEvent",
                Description = "This is the first event, EVER!!",
                Date = new DateTime(2015, 12, 01)
            });
        }
        // GET: Events
        public ActionResult Index(EventIndex viewModel)
        {
            if (viewModel == null)
            {
                viewModel = new EventIndex();
            }

            if (!viewModel.Month.HasValue)
            {
                viewModel.Month = DateTime.Now;
            }
            return View(viewModel);
        }

        public ActionResult Calendar(DateTime month)
        {
            var ec = new EventCalendar();
            ec.Month = month;
            ec.Events = events;
            return PartialView(ec);
        }

        public ActionResult EventInfoPane(int? id)
        {
            return PartialView(id);
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
    }
}