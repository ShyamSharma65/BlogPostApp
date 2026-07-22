using BlogPost.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogPostModel> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
