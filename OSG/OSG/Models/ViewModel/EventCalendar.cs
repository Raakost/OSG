using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gateway.DomainModel;

namespace OSG.Models.ViewModel
{
    public class EventCalendar
    {
        public DateTime Month { get; set; }
        public List<Event> Events { get; set; }
    }
}