namespace BlogManager.DTOs
{
    public class CreatePostDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = "Anonymous";
        public string Content { get; set; } = string.Empty;
    }
}
