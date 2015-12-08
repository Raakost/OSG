using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.DomainModel;
using DAL.Managers.IManager;

namespace DAL.Managers
{
    public class TrainerManager : IManager<Trainer>
    {
        public Trainer Create(Trainer model)
        {
            using (var ctx = new OSGContext())
            {
                ctx.Trainer.Attach(model);
                var trainerToReturn = ctx.Trainer.Add(model);
                ctx.SaveChanges();
                return trainerToReturn;
            }
        }

        public bool Delete(Trainer model)
        {
            using (var ctx = new OSGContext())
            {
                var trainerToDelete = ctx.Trainer.FirstOrDefault(trainer => trainer.Id == model.Id);
                if (trainerToDelete != null)
                {
                    ctx.Trainer.Remove(trainerToDelete);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<Trainer> ReadAll(int amound)
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Trainer.Include("Events").OrderBy(trainer => trainer.FirstName).ToList().Take(amound);
            }
        }

        public Trainer ReadByID(int Id)
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Trainer.Include("Events").FirstOrDefault(trainer => trainer.Id == Id);
            }
        }

        public Trainer Update(Trainer model)
        {
            using (var ctx = new OSGContext())
            {
                var trainerToUpdate = ctx.Trainer.FirstOrDefault(trainer => trainer.Id == model.Id);
                if (trainerToUpdate != null)
                {
                    trainerToUpdate.Description = model.Description;
                    trainerToUpdate.Email = model.Email;
                    trainerToUpdate.Events = model.Events.ToList();
                    trainerToUpdate.FirstName = model.FirstName;
                    trainerToUpdate.LastName = model.LastName;
                    trainerToUpdate.PhoneNo = model.PhoneNo;
                    trainerToUpdate.Picture = model.Picture;
                    ctx.SaveChanges();
                    return trainerToUpdate;
                }
                return model;
            }
        }
    }
}
