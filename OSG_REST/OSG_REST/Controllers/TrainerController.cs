using System;
using System.Collections.Generic;
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

        // This API call returns a list of trainers. The default amound of trainers returned is 10
        // unless otherwise specified differently when calling the API.

        // We use the [Route("route")] annotation here because we can't have two
        // HttpGet requests with the same methode structur (T SomeName(int number)). 
        // So we have to sepcify an alternative route for when we want to hit this method.
        [HttpGet]
        [Route("api/Trainer/GetByAmound/{amound}")]
        public IEnumerable<TrainerDTO> ReadAll(int amound = 10)
        {
            return new TrainerConverter().ConvertListToDTO(new Facade().GetTrainerManager().ReadAll(amound));
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
