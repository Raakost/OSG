using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OSG_DTO
{
    [DataContract]
    public class CommentDTO
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        [StringLength(500)]
        public string CommentText { get; set; }
        [DataMember]
        public NewsDTO News { get; set; }
    }
}
