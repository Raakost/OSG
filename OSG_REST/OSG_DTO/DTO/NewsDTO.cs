using System;
using System.Collections.Generic;

namespace OSG_DTO
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
