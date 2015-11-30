using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;


namespace OSG_DTO.Converter
{
    public class CommentConverter : AbstractDTOConverter<Comment, CommentDTO>
    {
        public override CommentDTO ConvertModel(Comment item)
        {
            var dto = new CommentDTO()
            {
                Id = item.Id,
                Name = item.Name,
                CommentText = item.CommentText,
            };
            if (item.News != null)
            {
                dto.News = new NewsDTO()
                {
                    Id = item.News.Id,
                    Date = item.News.Date,
                    Description = item.News.Description,
                    Picture = item.News.Picture,
                    Title = item.News.Title
                };
            }
            return dto;
        }
    }
}
