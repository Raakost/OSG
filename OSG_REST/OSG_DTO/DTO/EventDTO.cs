using System;
using System.Collections.Generic;

namespace OSG_DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<TrainerDTO> Trainers { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
