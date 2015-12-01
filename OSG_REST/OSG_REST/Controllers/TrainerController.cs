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
    public class TrainerController : ApiController, IOSGController<TrainerDTO>
    {
        [HttpPost]
        public TrainerDTO Create(TrainerDTO dto)
        {
            var trainer = new Facade().GetTrainerManager().Create(new TrainerConverter().ConvertDTO(dto));
            return new TrainerConverter().ConvertModel(trainer);
        }

        [HttpGet]
        public IEnumerable<TrainerDTO> ReadAll()
        {
            return new TrainerConverter().ConvertListToDTO(new Facade().GetTrainerManager().ReadAll());
        }

        [HttpGet]
        public TrainerDTO ReadById(int id)
        {
            return new TrainerConverter().ConvertModel(new Facade().GetTrainerManager().ReadByID(id));
        }

        [HttpPut]
        public TrainerDTO Update(int id, TrainerDTO dto)
        {
            dto.Id = id;
            var trainer = new Facade().GetTrainerManager().Update(new TrainerConverter().ConvertDTO(dto));
            return new TrainerConverter().ConvertModel(trainer);
        }

        [HttpDelete]
        public Boolean Delete(int id)
        {
            var trainer = new Trainer() { Id = id };
            if (new Facade().GetTrainerManager().Delete(trainer))
            {
                return true;
            }
            return false;
        }
    }
}
