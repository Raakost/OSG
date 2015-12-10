using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gateway.DomainModel;

namespace OSG.Models.ViewModel
{
    public class EventTrainers
    {

        public EventTrainers()
        {
            Trainers = new List<Trainer>();
            SelectedIDs = new List<int>();
        }
        public Event anEvent { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
        public List<int> SelectedIDs { get; set; }
    }
}
