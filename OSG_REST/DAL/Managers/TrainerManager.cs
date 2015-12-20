using System.Collections.Generic;
using System.Linq;
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
                // Calling attach here makes sure the model(Trainer)s events are tracked by the context
                // This way it will make a reference to an already existing event in the DB, instead of adding a new one, if it exists.
                // If the Event does not already exist, it will create it.
                ctx.Trainer.Attach(model);
                var trainerToReturn = ctx.Trainer.Add(model);
                ctx.SaveChanges();
                return trainerToReturn;
            }
        }

        // Delete a trainer with a given ID, if the ID can be found in the DB. Do nothing and return false if the Trainer does not exist.
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

        // Returns a IEnumerable with Trainers including their Events.
        public IEnumerable<Trainer> ReadAll()
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Trainer.Include("Events").ToList();
            }
        }

        // Returns a specific Trainer with a given ID, and include his Events for use if needed.
        public Trainer ReadByID(int Id)
        {
            using (var ctx = new OSGContext())
            {
                return ctx.Trainer.Include("Events").FirstOrDefault(trainer => trainer.Id == Id);
            }
        }

        // Updates the Trainers properies, except for Events. Use the EventManagers update to update an Event with Trainers.
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
