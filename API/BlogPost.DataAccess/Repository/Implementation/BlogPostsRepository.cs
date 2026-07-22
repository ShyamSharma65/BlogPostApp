using BlogPost.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.API.Repository.Implementation
{
    public class BlogPostsRepository
    {
        public readonly ApplicationDbContext _context;
        public BlogPostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogPosts(int id)
        {
            return null;
        }
    }
}
