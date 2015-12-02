using NUnit.Framework;
using DAL.DomainModel;

namespace TestDAL
{
    [TestFixture]
    class TestTrainerManager
    {
        private Trainer _trainer;
        [SetUp]
        public void Init()
        {
            _trainer = new Trainer()
            {
                Id = 1,
                FirstName = "Mikkel",
                LastName = "Madsen",
                Email = "mikkel@mail.com",
                PhoneNo = "22334455",
                Description = "A description",
            };
        }
        [Test]
        public void Test_Trainer_First_Name_Property()
        {
            Assert.AreEqual("Mikkel", _trainer.FirstName);
        }
    }
}
