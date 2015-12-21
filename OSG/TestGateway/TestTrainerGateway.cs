using System.Linq;
using NUnit.Framework;
using Gateway.DomainModel;
using Gateway.Services;

namespace TestGateway
{
    [TestFixture]
    class TestTrainerGateway
    {
        private Trainer _trainer1;
        private Trainer _trainer2;
        private Trainer _trainer3;

        private TrainerGatewayService _TrainerGateway;

        [SetUp]
        public void Init()
        {
            _TrainerGateway = new TrainerGatewayService();

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
        public void Test_ReadById_in_TrainerGateway_after_Create()
        {
            _trainer1 = _TrainerGateway.Create(_trainer1);
            Assert.AreNotEqual(null, _trainer1);

            int id = _TrainerGateway.ReadById(_trainer1.Id).Id;
            Assert.AreEqual(id, _trainer1.Id);
        }

        [Test]
        public void Test_Delete_Trainer_in_TrainerGateway_after_Create()
        {
            _trainer2 = _TrainerGateway.Create(_trainer2);
            Assert.AreNotEqual(null, _trainer2);

            var isDeleted = _TrainerGateway.Delete(_trainer2.Id);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_TrainerGateway_after_Create()
        {
            int count = _TrainerGateway.ReadAll().Count();
            _trainer3 = _TrainerGateway.Create(_trainer3);
            Assert.AreNotEqual(null, _trainer3);

            Assert.AreEqual(count+1, _TrainerGateway.ReadAll().Count());
        }

        [Test]
        public void Test_not_Updating_Trainer_in_TrainerGateway()
        {
            int noneExistingId = -1;

            var trainer = new Trainer()
            {
                Id = noneExistingId
            };

            var _recivedTrainer = _TrainerGateway.Update(trainer);

            Assert.AreEqual(trainer.Id, _recivedTrainer.Id);
        }

        [Test]
        public void Test_not_Deleting_Trainer_in_TrainerGateway()
        {
            int noneExistingId = -1;

            var trainer = new Trainer()
            {
                Id = noneExistingId
            };

            var isDeleted = _TrainerGateway.Delete(trainer.Id);
            
            Assert.AreEqual(false, isDeleted);
        }
    }
}
