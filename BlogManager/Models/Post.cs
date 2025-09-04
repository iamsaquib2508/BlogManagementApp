namespace BlogManager.Models
{
    public class Post
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = "Anonymous";
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
