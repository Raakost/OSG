using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using OSG_DTO;
using OSG_DTO.Converter;

namespace OSG_REST.Controllers
{
    public class TrainerController : ApiController
    {
        //[HttpPost]
        //public TrainerDTO Create(TrainerDTO dto)
        //{
        //    var trainer = new Facade().GetTrainerManager().Create();
        //    return new TrainerConverter().ConvertModel(trainer);
        //}
        [HttpGet]
        public IEnumerable<TrainerDTO> ReadAll()
        {
            return new TrainerConverter().Convert(new Facade().GetTrainerManager().ReadAll());
        }


    }
}
