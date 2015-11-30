using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;

namespace OSG_DTO.Converter
{
    public class NewsConverter : AbstractDTOConverter<News, NewsDTO>
    {
        public override NewsDTO ConvertModel(News item)
        {
            var dto = new NewsDTO()
            {
                Id = item.Id,
                Description = item.Description,
                Date = item.Date,
                Picture = item.Picture,
                Title = item.Title
            };
            if (item.Comments != null)
            {
                dto.Comments = new List<CommentDTO>();
                foreach (var comment in item.Comments)
                {
                    dto.Comments.Add(new CommentDTO()
                    {
                        Id = comment.Id,
                        CommentText = comment.CommentText,
                        Name = comment.Name
                    });
                }
            }
            return dto;
        }

        public override News ConvertDTO(NewsDTO item)
        {
            var model = new News()
            {
                Id = item.Id,
                Description = item.Description,
                Picture = item.Picture,
                Date = item.Date,
                Title = item.Title
            };
            if (item.Comments != null)
            {
                model.Comments = new List<Comment>();
                foreach (var comment in item.Comments)
                {
                    model.Comments.Add(new Comment()
                    {
                        Id = comment.Id,
                        CommentText = comment.CommentText,
                        Name = comment.Name
                    });
                }
            }
            return model;
        }
    }
}
