using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DAL.DomainModel
{
    [DataContract]
    public class Comment
    {
        public Comment()
        {
            //News = new News();
        }
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public News News { get; set; }

        [MaxLength(5000)]
        [DataMember]
        public string CommentText { get; set; }
    }
}
