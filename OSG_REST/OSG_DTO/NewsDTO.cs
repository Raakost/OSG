using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OSG_DTO
{
    [DataContract]
    public class NewsDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public IEnumerable<CommentDTO> Comments { get; set; }
    }
}
