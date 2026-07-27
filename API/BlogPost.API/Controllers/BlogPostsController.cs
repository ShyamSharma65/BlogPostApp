using BlogPost.BusinessLayer.Services.Interfaces;
using BlogPost.SharedLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPost()
        {
            var blogPosts = await _blogPostService.GetAllAsync();
            return Ok(blogPosts);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetBlogPostbyId(long id)
        {
            var blogPost = await _blogPostService.GetByIdAsync(id);
            if (blogPost is null)
            {
                return NotFound();
            }

            return Ok(blogPost);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBlogPost([FromBody] BlogPostDto blogPost)
        {
            if (blogPost is null)
            {
                return BadRequest();
            }

            var savedBlogPost = await _blogPostService.SaveAsync(blogPost);
            return CreatedAtAction(nameof(GetBlogPostbyId), new { id = savedBlogPost.Id }, savedBlogPost);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] BlogPostDto blogPost)
        {
            if (blogPost is null)
            {
                return BadRequest();
            }

            var updatedBlogPost = await _blogPostService.UpdateAsync(id, blogPost);
            if (updatedBlogPost is null)
            {
                return NotFound();
            }

            return Ok(updatedBlogPost);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _blogPostService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
