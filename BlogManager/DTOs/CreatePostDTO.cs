namespace BlogManager.DTOs
{
    public class CreatePostDTO
    {
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
