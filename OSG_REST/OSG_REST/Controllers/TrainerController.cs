using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using DAL;
using DAL.DomainModel;
using OSG_DTO;
using OSG_DTO.Converter;
using OSG_REST.Controllers.IController;
using System.Runtime.InteropServices;

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
