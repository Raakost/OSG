﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAL.DomainModel;

namespace OSG_DTO.Converter
{
    public class EventConverter : AbstractDTOConverter<Event, EventDTO>
    {
        public override EventDTO ConvertModel(Event item)
        {
            var dto = new EventDTO()
            {
                Id = item.Id,
                Date = item.Date,
                Description = item.Description,
                Title = item.Title,
            };
            if (item.Trainers != null)
            {
                dto.Trainers = new List<TrainerDTO>();
                foreach (var trainer in item.Trainers)
                {
                    dto.Trainers.Add(new TrainerDTO()
                    {
                        Id = trainer.Id,
                        Description = trainer.Description,
                        Picture = trainer.Picture,
                        Email = trainer.Email,
                        FirstName = trainer.FirstName,
                        LastName = trainer.LastName,
                        PhoneNo = trainer.PhoneNo
                    });
                }
            }
            return dto;
        }
    }
}
