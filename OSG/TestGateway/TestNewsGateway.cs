using System;
using System.Collections.Generic;
using System.Linq;
using Gateway.DomainModel;
using Gateway.Services;
using NUnit.Framework;

namespace TestGateway
{
    class TestNewsGateway
    {
        private News _news1;
        private News _news2;
        private News _news3;
        private NewsGatewayService _newsGateway;

        [SetUp]
        public void Init()
        {
            _newsGateway = new NewsGatewayService();

            _news1 = new News(){Title = "Test Title 1",Description = "Test Disc 1",Id = 1,Date = DateTime.Now,Picture = "/Content/Pictures/oprydning.jpg"};
            _news2 = new News() { Date = DateTime.Now, Title = "Test Title 2", Description = "Test Disc 2" };
            _news3 = new News() { Description = "Test Disc 3", Title = "Test Title 3", Id = 1 };
        }

        [Test]
        public void Test_ReadById_in_NewsGateway_after_Create()
        {
            _news1 = _newsGateway.Create(_news1);
            Assert.AreNotEqual(null, _news1);

            int id = _newsGateway.ReadById(_news1.Id).Id;
            Assert.AreEqual(id, _news1.Id);
        }

        [Test]
        public void Test_Delete_News_in_NewsGateway_after_Create()
        {
            _news2 = _newsGateway.Create(_news2);
            Assert.AreNotEqual(null, _news2);

            var isDeleted = _newsGateway.Delete(_news2.Id);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_NewsGateway_after_Create()
        {
            int count = _newsGateway.ReadAll().Count();
            _news3 = _newsGateway.Create(_news3);
            Assert.AreNotEqual(null, _news3);

            Assert.AreEqual(count + 1, _newsGateway.ReadAll().Count());
        }

        [Test]
        public void Test_not_Updating_News_in_NewsGateway()
        {
            int noneExistingId = -1;

            var news = new News()
            {
                Id = noneExistingId
            };

            var _recivedNews = _newsGateway.Update(news);

            Assert.AreEqual(news.Id, _recivedNews.Id);
        }

        [Test]
        public void Test_not_Deleting_News_in_NewsGateway()
        {
            int noneExistingId = -1;

            var news = new News()
            {
                Id = noneExistingId
            };

            var isDeleted = _newsGateway.Delete(news.Id);

            Assert.AreEqual(false, isDeleted);
        }
    }
}
