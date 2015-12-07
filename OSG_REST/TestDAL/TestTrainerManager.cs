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
            _trainerManager = new TrainerManager();
            
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
        public void Test_ReadAll_In_TrainerManager()
        {
            Assert.AreEqual(3, _trainerManager.ReadAll(10).Count());

            var testTrainer = _trainerManager.Create(_trainer2);
            Assert.AreEqual(_trainer2.Id, testTrainer.Id);

            Assert.AreEqual(4, _trainerManager.ReadAll(10).Count());
        }

        [Test]
        public void Test_ReadByID_In_TrainerManager()
        {
            Assert.AreEqual(_trainer1.Id, _trainerManager.ReadByID(_trainer1.Id).Id);
        }

        [Test]
        public void Test_ReadByID_In_TrainerManager_After_Create()
        {
            _trainerManager.Create(_trainer3);
            Assert.AreEqual(_trainer3.Id, _trainerManager.ReadByID(_trainer3.Id).Id);
        }

        [Test]
        public void Test_Delete_Trainer()
        {
            _trainerManager.Create(_trainer2);
            Assert.AreEqual(_trainer2.Id, _trainerManager.ReadByID(_trainer2.Id).Id);
            var IsDeleted = _trainerManager.Delete(_trainer2);
            Assert.AreEqual(true, IsDeleted);
        }
    }
}
