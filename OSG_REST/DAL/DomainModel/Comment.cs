namespace DAL.DomainModel
{
    public class Comment
    {
        public Comment()
        {
            News = new News();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public News News { get; set; }
        public string CommentText { get; set; }
    }
}
