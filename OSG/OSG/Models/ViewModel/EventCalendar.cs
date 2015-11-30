using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSG.Models.ViewModel
{
    public class EventCalendar
    {
        public List<Event> Events { get; set; }
        public List<Trainer> Trainers { get; set; }
    }
}