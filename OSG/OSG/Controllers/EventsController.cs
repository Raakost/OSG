using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSG.Models;
using OSG.Models.ViewModel;

namespace OSG.Controllers
{
    public class EventsController : Controller
    {
        List<Event> events = new List<Event>();

        public EventsController()
        {
            events.Add(new Event()
            {
                Id = 1,
                Title = "First Event",
                Description = "This is the first event, EVER!!",
                Date = new DateTime(2015, 12, 02)
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
    }
}