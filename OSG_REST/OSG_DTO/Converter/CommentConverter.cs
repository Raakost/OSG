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

        public override Comment ConvertDTO(CommentDTO item)
        {
            var model = new Comment()
            {
                Id = item.Id,
                CommentText = item.CommentText,
                Name = item.Name
            };

            if (item.News != null)
            {
                model.News = new News()
                {
                    Id = item.News.Id,
                    Description = item.News.Description,
                    Date = item.News.Date,
                    Picture = item.News.Picture,
                    Title = item.News.Title
                };
            }
            else
            {
                model.News = new News();
            }
            return model;
        }
    }
}
