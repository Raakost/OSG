using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DAL.DomainModel
{
    [DataContract(IsReference = true)]
    public class Trainer
    {
        public Trainer()
        {
            Events = new List<Event>();
        }
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Picture { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<Event> Events { get; set; }


    }
}