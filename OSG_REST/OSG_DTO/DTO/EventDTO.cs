using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OSG_DTO
{

    [DataContract(IsReference = true)]


    public class EventDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public List<TrainerDTO> Trainers { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Title { get; set; }
    }
}
