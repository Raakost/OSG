using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL.DomainModel
{
    [DataContract(IsReference = true)]
    public class Event
    {
        public Event()
        {
            Trainers = new List<Trainer>();
        }
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [DataMember]
        public List<Trainer> Trainers { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Title { get; set; }
    }
}
