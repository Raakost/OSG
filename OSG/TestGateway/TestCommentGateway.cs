using System.Linq;
using Gateway.DomainModel;
using Gateway.Services;
using NUnit.Framework;

namespace TestGateway
{
    class TestCommentGateway
    {
        private Comment _comment1;
        private Comment _comment2;
        private Comment _comment3;
        private CommentGatewayService _commentGateway;

        [SetUp]
        public void Init()
        {
            _commentGateway = new CommentGatewayService();

            _comment1 = new Comment() { Id = 1, CommentText = "Text 1", Name = "Name 1" };

            _comment2 = new Comment() { CommentText = "Text 2", Name = "Name 2" };

            _comment3 = new Comment() { CommentText = "Text 3", Name = "Name 3", Id = 2 };
        }

        [Test]
        public void Test_ReadById_in_CommentGateway_after_Create()
        {
            _comment1 = _commentGateway.Create(_comment1);
            Assert.AreNotEqual(null, _comment1);

            int id = _commentGateway.ReadById(_comment1.Id).Id;
            Assert.AreEqual(id, _comment1.Id);
        }

        [Test]
        public void Test_Delete_Comment_in_CommentGateway_after_Create()
        {
            _comment2 = _commentGateway.Create(_comment2);
            Assert.AreNotEqual(null, _comment2);

            var isDeleted = _commentGateway.Delete(_comment2.Id);
            Assert.AreEqual(true, isDeleted);
        }

        [Test]
        public void Test_ReadAll_in_CommentGateway_after_Create()
        {
            int count = _commentGateway.ReadAll().Count();
            _comment3 = _commentGateway.Create(_comment3);
            Assert.AreNotEqual(null, _comment3);

            Assert.AreEqual(count + 1, _commentGateway.ReadAll().Count());
        }

        [Test]
        public void Test_not_Updating_Comment_in_CommentGateway()
        {
            int noneExistingId = -1;

            var comment = new Comment()
            {
                Id = noneExistingId
            };

            var _recivedComment = _commentGateway.Update(comment);

            Assert.AreEqual(comment.Id, _recivedComment.Id);
        }

        [Test]
        public void Test_not_Deleting_Comment_in_CommentGateway()
        {
            int noneExistingId = -1;

            var comment = new Comment()
            {
                Id = noneExistingId
            };

            var isDeleted = _commentGateway.Delete(comment.Id);

            Assert.AreEqual(false, isDeleted);
        }
    }
}
