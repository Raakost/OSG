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

            //_trainer1 is the same trainer as in the DBSeed, used here for testing
            _trainer1 = new Trainer()
            {
                Id = 1,
                FirstName = "Mikkel",
                LastName = "Madsen",
                Email = "mikkel@mail.com",
                PhoneNo = "22334455",
                Description = "A description"
            };

            _trainer2 = new Trainer()
            {
                FirstName = "Rasmus"
            };
            _trainer3 = new Trainer()
            {
                Id = 3,
                FirstName = "Kim"
            };

        }

        //A test of how to do tests.
        [Test]
        public void Test_Trainer_First_Name_Property()
        {
            Assert.AreEqual("Mikkel", _trainerManager.ReadByID(_trainer1.Id).FirstName);
        }

        [Test]
        public void Test_ReadAll_In_TrainerManager()
        {
            Assert.AreEqual(1, _trainerManager.ReadAll().Count());
            var testTrainer = _trainerManager.Create(_trainer2);

            Assert.AreEqual(_trainer2.Id, testTrainer.Id);
            Assert.AreEqual(2, _trainerManager.ReadAll().Count());
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
            _trainerManager.Create(_trainer3);
            Assert.AreEqual(_trainer3.Id, _trainerManager.ReadByID(_trainer3.Id).Id);
            var IsDeleted = _trainerManager.Delete(_trainer3);
            Assert.AreEqual(true, IsDeleted);
        }
    }
}
