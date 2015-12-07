using System;
using System.Collections.Generic;

namespace DAL.DomainModel
{
    public class Event
    {
        public Event()
        {
            Trainers = new List<Trainer>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Trainer> Trainers { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
