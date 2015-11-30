using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;

namespace OSG_DTO.Converter
{
    public class TrainerConverter : AbstractDTOConverter<Trainer, TrainerDTO>
    {
        public override TrainerDTO ConvertModel(Trainer item)
        {
            var dto = new TrainerDTO()
            {
                Id = item.Id,
                Description = item.Description,
                Picture = item.Picture,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                PhoneNo = item.PhoneNo,
            };
            if (item.Events != null)
            {
                dto.Events = new List<EventDTO>();
                foreach (var anEvent in item.Events)
                {
                    dto.Events.Add(new EventDTO()
                    {
                        Id = anEvent.Id,
                        Description = anEvent.Description,
                        Date = anEvent.Date,
                        Title = anEvent.Title
                    });
                }
            }
            return dto;
        }
    }
}
