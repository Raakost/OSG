using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL.DomainModel
{
    [DataContract]
    public class News
    {
        public News()
        {
            Comments = new List<Comment>();
        }
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [DataMember]
        public string Picture { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public List<Comment> Comments { get; set; }
    }
}
