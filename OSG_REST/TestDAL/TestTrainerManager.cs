using System.Collections.Generic;
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

        [SetUp]
        public void Init()
        {
            _trainer1 = new Trainer()
            {
                Id = 4,
                FirstName = "Test FirstName 9",
                LastName = "Test LastName 9",
                Email = "Test9@mail.com",
                PhoneNo = "99119911",
                Description = "A description 9"
            };

            _trainer2 = new Trainer()
            {
                FirstName = "Test FirstName 10"
            };
            _trainer3 = new Trainer()
            {
                Id = 4,
                FirstName = "Test FirstName 11"
            };

        }

        [Test]
        public void Test_ReadAll_With_Count3_In_TrainerManager()
        {
            _trainerManager = new TrainerManager();
            int amound = 3;
            // The seed creates default 3+ trainers to the DB. Thats why
            // we test with ReadAll(3).
            Assert.AreEqual(amound, _trainerManager.ReadAll(amound).Count());

            _trainer1 = _trainerManager.Create(_trainer2);
            //amound++;
            Assert.AreEqual(amound+1, _trainerManager.ReadAll(amound+1).Count());
        }

        /// <summary>
        /// Test if the first ID in the DB can be read with ReadByID(int number)
        /// </summary>
        [Test]
        public void Test_ReadByID_In_TrainerManager()
        {
            _trainerManager = new TrainerManager();
            Assert.AreEqual(1, _trainerManager.ReadByID(1).Id);
        }

        [Test]
        public void Test_ReadByID_In_TrainerManager_After_Create()
        {
            _trainerManager = new TrainerManager();
            _trainer3 = _trainerManager.Create(_trainer3);
            Assert.AreEqual(_trainer3.Id, _trainerManager.ReadByID(_trainer3.Id).Id);
        }

        [Test]
        public void Test_Delete_Trainer()
        {
            _trainerManager = new TrainerManager();
            _trainer2 = _trainerManager.Create(_trainer2);
            Assert.AreEqual(_trainer2.Id, _trainerManager.ReadByID(_trainer2.Id).Id);
            var IsDeleted = _trainerManager.Delete(_trainer2);
            Assert.AreEqual(true, IsDeleted);
        }

        [Test]
        public void Test_Update_Discription_Trainer_After_Create()
        {
            _trainerManager = new TrainerManager();
            var testDescription = "Create Description";
            var _trainer4 = _trainerManager.Create(new Trainer()
            {
                Id = 1,
                FirstName = "Test First Name 12",
                Description = testDescription,
            });

            Assert.AreEqual(testDescription, _trainer4.Description);

            _trainer4.Description = "New Description";
            _trainer4 = _trainerManager.Update(_trainer4);

            Assert.AreEqual(_trainer4.Description, _trainerManager.ReadByID(_trainer4.Id).Description);
        }

        [Test]
        public void Test_Update_Events_On_Trainer()
        {
            var _event =
            new Event() {Title = "Test title", Id = 1};

            _trainerManager = new TrainerManager();
            var _trainer5 = _trainerManager.ReadByID(1);
            Assert.AreEqual(_trainer5.Id, _trainerManager.ReadByID(_trainer5.Id).Id);

            _trainer5.Events = new List<Event>() {_event};
            _trainer5 = _trainerManager.Update(_trainer5);
            Assert.AreEqual(_event.Id, _trainer5.Events[0].Id);

            var _event1 = new Event() {Title = "Test title2", Id = 1};
            _trainer5.Events = new List<Event>() {_event1};
            _trainer5 = _trainerManager.Update(_trainer5);
            Assert.AreEqual(_event1.Id, _trainer5.Events[0].Id);
        }
    }
}
