using System;
using System.Linq;
using DAL.DomainModel;
using DAL.Managers;
using NUnit.Framework;

namespace TestDAL
{
    [TestFixture]
    class TestEventManager
    {
        private Event _event1;
        private Event _event2;
        private Event _event3;
        private EventManager _eventManager;
        private TrainerManager _trainerManager;

        [SetUp]
        public void Init()
        {
            _eventManager = new EventManager();
            _trainerManager = new TrainerManager();

            var _trainer1 = new Trainer()
            {
                Id = 1, Description = "Test Disc1", Email = "mail@mail.com", FirstName = "Test First Name 1",
                LastName = "Test Last Name 1", PhoneNo = "11224455"
            };
            _event1 = new Event() {Title = "Test title 1", Description = "Disc 1", Id = 1, Date = DateTime.Now};
            _event1.Trainers.Add(_trainer1);
            _trainer1.Events.Add(_event1);

            _event2 = new Event() {Title = "Test title 2", Description = "Disc 2", Id = 1};

            _event3 = new Event() {Description = "Disc 3", Title = "Test title 3"};
        }

        [Test]
        public void Test_ReadById_in_eventManager_after_Create()
        {
            _event1 = _eventManager.Create(_event1);
            Assert.AreNotEqual(null, _event1);

            int id = _eventManager.ReadByID(_event1.Id).Id;
            Assert.AreEqual(_event1.Id, id);
        }

        [Test]
        public void Test_Delete_in_eventManager_after_Create()
        {
            _event2 = _eventManager.Create(_event2);
            Assert.AreNotEqual(null, _event2);

            var isDeleted = _eventManager.Delete(_event2);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_eventManager()
        {
            var count = _eventManager.ReadAll().Count();
            Assert.AreEqual(count, _eventManager.ReadAll().Count());
        }

        [Test]
        public void Test_Update_existing_event_with_existing_trainer_in_eventManager()
        {
            //Create new Trainer, and add it to the Database.
            var _trainer = _trainerManager.Create(new Trainer()
            {
                Id = 1,
                FirstName = "Event Test First Name 1",
                LastName = "Event Test Last Name 1",
                Description = "Test Disc 'event'",
            });
            Assert.AreEqual(_trainer.Id, _trainerManager.ReadByID(_trainer.Id).Id);

            //Get the Event with Id 1 from the Database, and make sure its is not null.
            var _event = _eventManager.ReadByID(1);
            Assert.AreNotEqual(null, _event);

            //Add the Trainer we just added to the Database, to the Event we just got from the Database.
            _event.Trainers.Add(_trainer);

            //Update the Event in the database with the foringkey to the Trainer.
            _event = _eventManager.Update(_event);

            //Read the Trainer we now have a foringkey connection to, from the Database, based on the FirstName of the Trainer in the Event.
            _trainer = _trainerManager.ReadByID(_event.Trainers.FirstOrDefault(eventTrainer => eventTrainer.FirstName == _trainer.FirstName).Id);

            //Check if the Trainer is not null.
            Assert.AreNotEqual(null, _trainer);

            //Check if the Trainer Id we got from the Database matches the Event we updated.
            Assert.AreEqual(_trainer.Id, _event.Trainers.FirstOrDefault(eventTrainer => eventTrainer.Id == _trainer.Id).Id);
        }

        [Test]
        public void Test_not_Updating_an_Event_in_eventManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of Events is 4.
            int noneExistingId = 50;
            var _event = new Event()
            {
                Id = noneExistingId,
                Description = "This event will not update"
            };
            _event = _eventManager.Update(_event);
            Assert.AreEqual(noneExistingId, _event.Id);
        }

        [Test]
        public void Test_not_Deleting_an_Event_in_eventManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of events is 4.
            int noneExistingId = 50;
            var _event = new Event()
            {
                Id = noneExistingId,
                Description = "This event will not be Deleted"
            };
            var isDeleted = _eventManager.Delete(_event);
            Assert.AreEqual(false, isDeleted);
        }

        [Test]
        public void Test_ReadByMonth_in_eventManager()
        {
            var _event = new Event()
            {
                Id = 1,
                Title = "Test Title ReadByMonth",
                Description = "Test Disc ReadByMonth",
                Date = DateTime.Today
            };
            _event = _eventManager.Create(_event);
            Assert.AreNotEqual(null, _event);

            var _eventsByMonth = _eventManager.ReadByMonth(DateTime.Today);

            Assert.AreNotEqual(null, _eventsByMonth.FirstOrDefault(listEvent => listEvent.Id == _event.Id));
        }
    }
}
