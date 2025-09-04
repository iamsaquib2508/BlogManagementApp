using Microsoft.EntityFrameworkCore;
using BlogManager.Models;

namespace BlogManager.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }  // Table for Posts
    }
}
