using System.Collections.Generic;
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
        private CommentManager commentManager;
            
        [SetUp]
        public void Init()
        {
            var news = new List<News>()
            {
                new News() {Description = "Disc 1", Title = "Test title 1"}
            };
            _comment1 = new Comment() {CommentText = "Text 1", Name = "Name 1", News = news};

            _comment2 = new Comment() { CommentText = "Text 2", Name = "Name 2"};

            _comment3 = new Comment() {CommentText = "Text 3", Name = "Name 3", Id = 1};
        }
    }
}
