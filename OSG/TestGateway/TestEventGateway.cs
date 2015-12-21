
using System;
using System.Linq;
using Gateway.DomainModel;
using Gateway.Services;
using NUnit.Framework;

namespace TestGateway
{
    [TestFixture]
    class TestEventGateway
    {
        private Event _event1;
        private Event _event2;
        private Event _event3;

        private EventGatewayService _EventGateway;
        private TrainerGatewayService _TrainerGateway;

        [SetUp]
        public void Init()
        {
            _EventGateway = new EventGatewayService();
            _TrainerGateway = new TrainerGatewayService();

            _event1 = new Event() { Title = "Test title 1", Description = "Disc 1", Id = 1, Date = DateTime.Now };

            _event2 = new Event() { Title = "Test title 2", Description = "Disc 2", Id = 1 };

            _event3 = new Event() { Description = "Disc 3", Title = "Test title 3" };
        }

        [Test]
        public void Test_Update_existing_Event_with_existing_Trainer_in_EventGateway()
        {
            var trainer = _TrainerGateway.ReadById(1);
            Assert.AreNotEqual(null, trainer);

            var _event = _EventGateway.ReadById(3);
            Assert.AreNotEqual(null, _event);

            _event.Trainers.Add(trainer);
            int trainerIdBeforeUpdate = trainer.Id;
            _event = _EventGateway.Update(_event);

            var trainerAfterUpdate = _event.Trainers.FirstOrDefault(eventTrainer => eventTrainer.Id == trainerIdBeforeUpdate);
            Assert.AreEqual(trainerIdBeforeUpdate, trainerAfterUpdate.Id);
        }

        [Test]
        public void Test_ReadById_in_Eventteway_after_Create()
        {
            _event1 = _EventGateway.Create(_event1);
            Assert.AreNotEqual(null, _event1);

            int id = _EventGateway.ReadById(_event1.Id).Id;
            Assert.AreEqual(id, _event1.Id);
        }

        [Test]
        public void Test_Delete_Trainer_in_EventGateway_after_Create()
        {
            _event2 = _EventGateway.Create(_event2);
            Assert.AreNotEqual(null, _event2);

            var isDeleted = _EventGateway.Delete(_event2.Id);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_EventGateway_after_Create()
        {
            int count = _EventGateway.ReadAll().Count();
            _event3 = _EventGateway.Create(_event3);
            Assert.AreNotEqual(null, _event3);

            Assert.AreEqual(count + 1, _EventGateway.ReadAll().Count());
        }

        [Test]
        public void Test_not_Updating_Event_in_EventGateway()
        {
            int noneExistingId = -1;

            var _event = new Event()
            {
                Id = noneExistingId
            };

            var _recivedEvent = _EventGateway.Update(_event);

            Assert.AreEqual(_event.Id, _recivedEvent.Id);
        }

        [Test]
        public void Test_not_Deleting_Event_in_EventGateway()
        {
            int noneExistingId = -1;

            var _event = new Event()
            {
                Id = noneExistingId
            };

            var isDeleted = _EventGateway.Delete(_event.Id);

            Assert.AreEqual(false, isDeleted);
        }

        [Test]
        public void Test_ReadByMonth_in_EventGateway()
        {
            var _event = new Event()
            {
                Id = 1,
                Date = DateTime.Today
            };
            _event = _EventGateway.Create(_event);
            Assert.AreNotEqual(null, _event);

            var _eventsByMonth = _EventGateway.ReadByMonth(DateTime.Today);

            Assert.AreNotEqual(null, _eventsByMonth.FirstOrDefault(listEvent => listEvent.Id == _event.Id));
        }
    }
}
