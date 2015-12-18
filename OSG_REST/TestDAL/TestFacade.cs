using DAL;
using DAL.Managers;
using NUnit.Framework;

namespace TestDAL
{
    [TestFixture]
    class TestFacade
    {
        private Facade facade;

        [SetUp]
        public void Init()
        {
            facade = new Facade();
        }

        [Test]
        public void Test_Get_EventManager_in_Facade()
        {
            Assert.AreEqual(typeof (EventManager), facade.GetEventManager().GetType());
        }

        [Test]
        public void Test_Get_CommentManager_in_Facade()
        {
            Assert.AreEqual(typeof(CommentManager), facade.GetCommentManager().GetType());
        }

        [Test]
        public void Test_Get_TrainerManager_in_Facade()
        {
            Assert.AreEqual(typeof(TrainerManager), facade.GetTrainerManager().GetType());
        }

        [Test]
        public void Test_Get_NewsManager_in_Facade()
        {
            Assert.AreEqual(typeof(NewsManager), facade.GetNewsManager().GetType());
        }
    }
}
