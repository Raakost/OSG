using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DomainModel
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public News News { get; set; }
        public string CommentText { get; set; }
    }
}
