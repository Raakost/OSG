using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DomainModel
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Trainer> Trainers { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
