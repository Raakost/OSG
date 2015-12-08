using System.Collections.Generic;
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

        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void Test_Update_Trainer_On_Events()
        {
            var _trainer = new Trainer() {Id = 1, FirstName = "Hubba", LastName = "Bubba"};

            _eventManager = new EventManager();
            var _event5 = _eventManager.ReadByID(1);
            Assert.AreEqual(_event5.Id, _eventManager.ReadByID(_event5.Id).Id);

            _event5.Trainers = new List<Trainer>() {_trainer};
            _event5 = _eventManager.Update(_event5);
            Assert.AreEqual(_trainer.Id, _event5.Trainers[0].Id);

            var _trainer1 = new Trainer() {Id = 1, FirstName = "Loko", LastName = "Derp"};
            _event5.Trainers = new List<Trainer>() {_trainer1};
            _event5 = _eventManager.Update(_event5);
            Assert.AreEqual(_trainer1.Id, _event5.Trainers[0].Id);
        }
    }
}
