using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DomainModel;
using DAL.Managers;
using NUnit.Framework;

namespace TestDAL
{
    [TestFixture]
    class TestCommentManager
    {
        private Comment _comment1;
        private Comment _comment2;
        private Comment _comment3;
        private CommentManager _commentManager;
        private NewsManager _newsManager;
            
        [SetUp]
        public void Init()
        {
            _commentManager = new CommentManager();
            _newsManager = new NewsManager();

            _comment1 = new Comment() {Id = 1, CommentText = "Text 1", Name = "Name 1"};
            var news = new News() {Id = 1, Description = "Disc 1", Title = "Test title 1", Date = DateTime.Now, Picture = "/Content/Pictures/oprydning.jpg" };
            news.Comments.Add(_comment1);
            _comment1.News = news;

            _comment2 = new Comment() {CommentText = "Text 2", Name = "Name 2"};

            _comment3 = new Comment() {CommentText = "Text 3", Name = "Name 3", Id = 1};
        }

        [Test]
        public void Test_ReadById_in_commentManager_after_Create()
        {
            //When we Create this Comment. The News inside will then have the correct foringkey to its News in the DB.
            _comment1 = _commentManager.Create(_comment1);
            Assert.AreNotEqual(null, _comment1);

            int id = _commentManager.ReadByID(_comment1.Id).Id;
            Assert.AreEqual(_comment1.Id, id);
        }

        [Test]
        public void Test_Delete_in_commentManager_after_Create()
        {
            _comment2 = _commentManager.Create(_comment2);
            Assert.AreNotEqual(null, _comment2);

            var isDeleted = _commentManager.Delete(_comment2);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_commentManager()
        {
            var count = _commentManager.ReadAll().Count();
            Assert.AreEqual(count, _commentManager.ReadAll().Count());
        }

        [Test]
        public void Test_Update_Comment_in_commentManager()
        {
            var _commentToUpdate = _commentManager.Create(_comment3);
            Assert.AreEqual(_commentToUpdate.Name, _comment3.Name);

            string newName = "Comment Test Name 3 Updated";
            _commentToUpdate.Name = newName;
            _commentToUpdate = _commentManager.Update(_commentToUpdate);
            Assert.AreEqual(_commentToUpdate.Name, newName);
        }

        [Test]
        public void Test_not_Updating_a_Comment_in_commentManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of news is 9.
            int noneExistingId = 50;
            var _comment = new Comment()
            {
                Id = noneExistingId,
                Name = "I will not be deleted1",
                CommentText = "This news will not update"
            };
            _comment = _commentManager.Update(_comment);
            Assert.AreEqual(noneExistingId, _comment.Id);
        }

        [Test]
        public void Test_not_Deleting_a_Comment_in_commentManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of news is 9.
            int noneExistingId = 50;
            var _comment = new Comment()
            {
                Id = noneExistingId,
                Name = "I will not be deleted1",
                CommentText = "This news will not update"
            };
            var isDeleted = _commentManager.Delete(_comment);
            Assert.AreEqual(false, isDeleted);
        }
    }
}
