using System;
using System.Linq;
using NUnit.Framework;
using DAL.DomainModel;
using DAL.Managers;

namespace TestDAL
{
    [TestFixture]
    class TestTrainerManager
    {
        private Trainer _trainer1;
        private Trainer _trainer2;
        private Trainer _trainer3;
        private TrainerManager _trainerManager;
        private EventManager _eventManager;

        [SetUp]
        public void Init()
        {
            _trainerManager = new TrainerManager();
            _eventManager = new EventManager();

            _trainer1 = new Trainer()
            {
                Id = 1,
                FirstName = "Test FirstName 9",
                LastName = "Test LastName 9",
                Email = "Test9@mail.com",
                PhoneNo = "99119911",
                Description = "A description 9"
            };

            _trainer2 = new Trainer()
            {
                Id = 2,
                FirstName = "Test FirstName 10"
            };
            _trainer3 = new Trainer()
            {
                Id = 3,
                FirstName = "Test FirstName 11"
            };
        }

        [Test]
        public void Test_ReadById_in_trainerManager_after_Create()
        {
            _trainer1 = _trainerManager.Create(_trainer1);
            Assert.AreNotEqual(null, _trainer1);

            int id = _trainerManager.ReadByID(_trainer1.Id).Id;
            Assert.AreEqual(_trainer1.Id, id);
        }

        [Test]
        public void Test_Delete_in_trainerManager_after_Create()
        {
            _trainer2 = _trainerManager.Create(_trainer2);
            Assert.AreNotEqual(null, _trainer2);

            var isDeleted = _trainerManager.Delete(_trainer2);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_trainerManager()
        {
            var count = _trainerManager.ReadAll().Count();
            Assert.AreEqual(count, _trainerManager.ReadAll().Count());
        }

        [Test]
        public void Test_Update_existing_trainer_with_existing_event_in_trainerManager()
        {
            //Create new event, and add it to the Database.
            var _event = _eventManager.Create(new Event()
            {
                Id = 1,
                Title = "Test title 'trainer'",
                Description = "Test disc 'trainer'",
                Date = DateTime.Now
            });
            Assert.AreEqual(_event.Id, _eventManager.ReadByID(_event.Id).Id);

            //Get the trainer with Id 1 from the Database, and make sure he is not null.
            var _trainer = _trainerManager.ReadByID(1);
            Assert.AreNotEqual(null, _trainer);

            //Add the Event we just added to the Database, to the Trainer we just got from the Database.
            _trainer.Events.Add(_event);

            //Update the Trainer in the database with the foringkey to the Event.
            _trainer = _trainerManager.Update(_trainer);

            //Read the Event we now have a foringkey connection to, from the Database, based on the Title of the Event in the Trainer.
            _event = _eventManager.ReadByID(_trainer.Events.FirstOrDefault(trainerEvent => trainerEvent.Title == _event.Title).Id);

            //Check if the Event is not null.
            Assert.AreNotEqual(null, _event);

            //Check if the Event Id we got from the Database matches the Trainer we updated.
            Assert.AreEqual(_event.Id, _trainer.Events.FirstOrDefault(trainerEvent => trainerEvent.Id == _event.Id).Id);
        }

        [Test]
        public void Test_not_Updating_a_Trainer_in_trainerManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of trainers is 3.
            int noneExistingId = 50;
            var _trainer = new Trainer()
            {
                Id = noneExistingId,
                FirstName = "Huggo",
                LastName = "Boss",
                Description = "This trainer will not update"
            };
            _trainer = _trainerManager.Update(_trainer);
            Assert.AreEqual(noneExistingId, _trainer.Id);
        }

        [Test]
        public void Test_not_Deleting_a_Trainer_in_trainerManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of trainers is 3.
            int noneExistingId = 50;
            var _trainer = new Trainer()
            {
                Id = noneExistingId,
                FirstName = "Bobby",
                LastName = "Stein",
                Description = "This trainer will not update"
            };
            var isDeleted = _trainerManager.Delete(_trainer);
            Assert.AreEqual(false, isDeleted);
        }
    }
}
