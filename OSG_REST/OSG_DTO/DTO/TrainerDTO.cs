using System.Collections.Generic;

namespace OSG_DTO
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public List<EventDTO> Events { get; set; }
    }
}
