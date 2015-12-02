﻿using System.Collections.Generic;
using System.Web.Http;
using DAL;
using DAL.DomainModel;
using OSG_DTO;
using OSG_DTO.Converter;
using OSG_REST.Controllers.IController;

namespace OSG_REST.Controllers
{
    public class CommentController : ApiController, IOSGController<CommentDTO>
    {
        [HttpPost]
        public CommentDTO Create(CommentDTO dto)
        {
            var comment = new Facade().GetCommentManager().Create(new CommentConverter().ConvertDTO(dto));
            return new CommentConverter().ConvertModel(comment);
        }

        [HttpGet]
        public CommentDTO ReadById(int id)
        {
            return new CommentConverter().ConvertModel(new Facade().GetCommentManager().ReadByID(id));
        }

        [HttpGet]
        public IEnumerable<CommentDTO> ReadAll(int amound = 10)
        {
            return new CommentConverter().ConvertListToDTO(new Facade().GetCommentManager().ReadAll(amound));
        }

        [HttpPut]
        public CommentDTO Update(int id, CommentDTO dto)
        {
            dto.Id = id;
            var comment = new Facade().GetCommentManager().Update(new CommentConverter().ConvertDTO(dto));
            return new CommentConverter().ConvertModel(comment);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var comment = new Comment() { Id = id };
            if (new Facade().GetCommentManager().Delete(comment))
            {
                return true;
            }
            return false;
        }
    }
}
