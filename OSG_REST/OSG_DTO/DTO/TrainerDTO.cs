using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OSG_DTO
{
    [DataContract]
    public class TrainerDTO
    {
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
        public List<EventDTO> Events { get; set; }
    }
}
