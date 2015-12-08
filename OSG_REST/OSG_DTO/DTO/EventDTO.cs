using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OSG_DTO
{
    [DataContract(IsReference = true)]
    public class EventDTO
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public List<TrainerDTO> Trainers { get; set; }
        [DataMember]
        [StringLength(5000)]
        public string Description { get; set; }
        [DataMember]
        public string Title { get; set; }
    }
}
