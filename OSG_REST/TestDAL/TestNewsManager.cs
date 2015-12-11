using System;
using DAL.DomainModel;
using DAL.Managers;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestDAL
{
    [TestFixture]
    class TestNewsManager
    {
        private News _news1;
        private News _news2;
        private News _news3;
        private NewsManager _newsManager;

        [SetUp]
        public void Init()
        {
            var comments = new List<Comment>()
            {
                new Comment() {CommentText = "Text1", Name = "Name1"},
                new Comment() {CommentText = "Text2", Name = "Name2"}
            };
            _news1 = new News(){Title = "Test title 1", Description = "Disc 1", Comments = comments};
            _news2 = new News() {Date = DateTime.Now, Title = "Test title 2", Description = "disc 2"};
            _news3 = new News() {Description = "disc 3", Title = "Test title 3", Id = 1};
        }

        [Test]
        public void Test_ReadByID_In_NewsManager()
        {
            _newsManager = new NewsManager();
            Assert.AreEqual(1, _newsManager.ReadByID(1).Id);
        }

        [Test]
        public void Test_ReadByID_In_NewsManager_After_Create()
        {
            _newsManager = new NewsManager();
            _news3 = _newsManager.Create(_news3);
            Assert.AreEqual(_news3.Id, _newsManager.ReadByID(_news3.Id).Id);
        }

        [Test]
        public void Test_Delete_News()
        {
            _newsManager = new NewsManager();
            _news2 = _newsManager.Create(_news2);
            Assert.AreEqual(_news2.Id, _newsManager.ReadByID(_news2.Id).Id);
            var IsDeleted = _newsManager.Delete(_news2);
            Assert.AreEqual(true, IsDeleted);
        }

        [Test]
        public void Test_Update_Discription_On_News_After_Create()
        {
            _newsManager = new NewsManager();
            var testDescription = "Create Description";
            var _news4 = _newsManager.Create(new News()
            {
                Id = 1,
                Title = "Test Title 12",
                Description = testDescription,
            });

            Assert.AreEqual(testDescription, _news4.Description);

            _news4.Description = "New Description";
            _news4 = _newsManager.Update(_news4);

            Assert.AreEqual(_news4.Description, _newsManager.ReadByID(_news4.Id).Description);
        }
    }
}
