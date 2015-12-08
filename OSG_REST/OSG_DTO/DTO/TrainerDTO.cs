using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OSG_DTO
{

    [DataContract(IsReference = true)]

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
