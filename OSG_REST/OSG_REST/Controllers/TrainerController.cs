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

namespace OSG_REST.Controllers
{
    public class TrainerController : ApiController
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
        public TrainerDTO ReadById(int Id)
        {
            return new TrainerConverter().ConvertModel(new Facade().GetTrainerManager().ReadByID(Id));
        }

        [HttpPut]
        public TrainerDTO Update(int Id, TrainerDTO dto)
        {
            dto.Id = Id;
            var trainer = new Facade().GetTrainerManager().Update(new TrainerConverter().ConvertDTO(dto));
            return new TrainerConverter().ConvertModel(trainer);
        }

        [HttpDelete]
        public Boolean Delete(int Id)
        {
            var trainer = new Trainer() {Id = Id};
            if (new Facade().GetTrainerManager().Delete(trainer))
            {
                return true;
            }
            return false;
        }
    }
}
