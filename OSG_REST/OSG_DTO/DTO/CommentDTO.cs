namespace OSG_DTO
{
    
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public NewsDTO News { get; set; }
    }
}
