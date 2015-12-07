using System;
using System.Collections.Generic;

namespace DAL.DomainModel
{
    public class News
    {
        public News()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
