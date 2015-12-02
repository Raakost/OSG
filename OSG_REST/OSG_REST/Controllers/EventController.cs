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

namespace OSG_REST.Controllers
{
    public class EventController : ApiController, IOSGController<EventDTO>
    {
        [HttpPost]
        public EventDTO Create(EventDTO dto)
        {
            var _event = new Facade().GetEventManager().Create(new EventConverter().ConvertDTO(dto));
            return new EventConverter().ConvertModel(_event);
        }

        [HttpGet]
        public IEnumerable<EventDTO> ReadAll(int amound = 10)
        {
            return new EventConverter().ConvertListToDTO(new Facade().GetEventManager().ReadAll(amound));
        }

        [HttpGet]
        public EventDTO ReadById(int id)
        {
            return new EventConverter().ConvertModel(new Facade().GetEventManager().ReadByID(id));
        }

        [HttpPut]
        public EventDTO Update(int id, EventDTO dto)
        {
            dto.Id = id;
            var _event = new Facade().GetEventManager().Update(new EventConverter().ConvertDTO(dto));
            return new EventConverter().ConvertModel(_event);
        }

        [HttpDelete]
        public Boolean Delete(int id)
        {
            var _event = new Event() { Id = id };
            if (new Facade().GetEventManager().Delete(_event))
            {
                return true;
            }
            return false;
        }
    }
}
