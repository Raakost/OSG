using System.Runtime.Serialization;

namespace OSG_DTO
{
    [DataContract]
    public class CommentDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CommentText { get; set; }
        [DataMember]
        public NewsDTO News { get; set; }
    }
}
