using System;
using DAL.DomainModel;
using DAL.Managers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestDAL
{
    [TestFixture]
    class TestNewsManager
    {
        private News _news1;
        private News _news2;
        private News _news3;
        private NewsManager _newsManager;
        private CommentManager _commentManager;
        private List<Comment> comments;

        [SetUp]
        public void Init()
        {
            _newsManager = new NewsManager();
            _commentManager = new CommentManager();

            //Create a list of Comments to add to a News.
            comments = new List<Comment>()
            {
                new Comment() {Id = 1, CommentText = "News Test Text1", Name = "News Test Name1"},
                new Comment() {Id = 2, CommentText = "News Test Text2", Name = "News Test Name2"}
            };

            //Create a News and set its Comments to be squal to the above Commentlist.
            _news1 = new News()
            {
                Title = "Test Title 1", Description = "Test Disc 1", Comments = comments, Id = 1,
                Date = DateTime.Now, Picture = "/Content/Pictures/oprydning.jpg"
            };

            //Create the Comments in the DB.
            foreach (var comment in comments)
            {
                _commentManager.Create(comment);
            }


            _news2 = new News() {Date = DateTime.Now, Title = "Test Title 2", Description = "Test Disc 2"};
            _news3 = new News() {Description = "Test Disc 3", Title = "Test Title 3", Id = 1};
        }

        [Test]
        public void Test_ReadById_in_newsManager_after_Create()
        {
            //When we Create this News. The list of Comments inside, will then have the correct foringkey to this News.
            _news1 = _newsManager.Create(_news1);
            Assert.AreNotEqual(null, _news1);

            int id = _newsManager.ReadByID(_news1.Id).Id;
            Assert.AreEqual(_news1.Id, id);
        }

        [Test]
        public void Test_Delete_in_newsManager_after_Create()
        {
            _news2 = _newsManager.Create(_news2);
            Assert.AreNotEqual(null, _news2);

            var isDeleted = _newsManager.Delete(_news2);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_newsManager()
        {
            var count = _newsManager.ReadAll().Count();
            Assert.AreEqual(count, _newsManager.ReadAll().Count());
        }

        [Test]
        public void Test_Update_News_in_newsManager()
        {
            var _newsToUpdate = _newsManager.Create(_news3);
            Assert.AreEqual(_newsToUpdate.Title, _news3.Title);

            string newTitle = "News Test Title 3 Updated";
            _newsToUpdate.Title = newTitle;
            _newsToUpdate = _newsManager.Update(_newsToUpdate);
            Assert.AreEqual(_newsToUpdate.Title, newTitle);
        }

        [Test]
        public void Test_not_Updating_a_News_in_newsManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of news is 9.
            int noneExistingId = 50;
            var _news = new News()
            {
                Id = noneExistingId,
                Title = "I will not be deleted1",
                Description = "This news will not update"
            };
            _news = _newsManager.Update(_news);
            Assert.AreEqual(noneExistingId, _news.Id);
        }

        [Test]
        public void Test_not_Deleting_a_News_in_newsManager()
        {
            //Id 50 is not existing in the Database. We remake the Database with a new seed every time the application runs.
            //The default amound of news is 9.
            int noneExistingId = 50;
            var _news = new News()
            {
                Id = noneExistingId,
                Title = "I will not be deleted2",
                Description = "This news will not update"
            };
            var isDeleted = _newsManager.Delete(_news);
            Assert.AreEqual(false, isDeleted);
        }
    }
}
