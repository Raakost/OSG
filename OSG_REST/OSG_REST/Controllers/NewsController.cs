using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DAL.DomainModel;
using OSG_DTO;
using OSG_DTO.Converter;
using OSG_REST.Controllers.IController;
using System.Runtime.InteropServices;

namespace OSG_REST.Controllers
{
    public class NewsController : ApiController, IOSGController<NewsDTO>
    {
        [HttpPost]
        public NewsDTO Create(NewsDTO dto)
        {
            var news = new Facade().GetNewsManager().Create(new NewsConverter().ConvertDTO(dto));
            return new NewsConverter().ConvertModel(news);
        }

        [HttpGet]
        public NewsDTO ReadById(int id)
        {
            return new NewsConverter().ConvertModel(new Facade().GetNewsManager().ReadByID(id));
        }

        [HttpGet]
        [Route("api/News/GetByAmound/{amound}")]
        public IEnumerable<NewsDTO> ReadAll(int amound)
        {
            return new NewsConverter().ConvertListToDTO(new Facade().GetNewsManager().ReadAll(amound));
        }

        [HttpPut]
        public NewsDTO Update(int id, NewsDTO dto)
        {
            dto.Id = id;
            var news = new Facade().GetNewsManager().Update(new NewsConverter().ConvertDTO(dto));
            return new NewsConverter().ConvertModel(news);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var news = new News() { Id = id };
            if (new Facade().GetNewsManager().Delete(news))
            {
                return true;
            }
            return false;
        }
    }
}
