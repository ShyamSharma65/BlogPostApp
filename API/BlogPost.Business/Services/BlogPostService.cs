using BlogPost.API.Repository.Interface;
using BlogPost.BusinessLayer.Services.Interfaces;
using BlogPost.SharedLibrary.Models;

namespace BlogPost.BusinessLayer.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostsRepository _blogPostsRepository;

        public BlogPostService(IBlogPostsRepository blogPostsRepository)
        {
            _blogPostsRepository = blogPostsRepository;
        }

        public async Task<List<BlogPostDto>> GetAllAsync()
        {
            return await _blogPostsRepository.GetAllAsync();
        }

        public async Task<BlogPostDto?> GetByIdAsync(long id)
        {
            return await _blogPostsRepository.GetByIdAsync(id);
        }

        public async Task<BlogPostDto> SaveAsync(BlogPostDto blogPost)
        {
            blogPost.CreatedOn = DateTime.Now;
            return await _blogPostsRepository.SaveAsync(blogPost);
        }

        public async Task<BlogPostDto?> UpdateAsync(long id, BlogPostDto blogPost)
        {
            blogPost.ModifiedOn = DateTime.Now;
            return await _blogPostsRepository.UpdateAsync(id, blogPost);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _blogPostsRepository.DeleteAsync(id);
        }
    }
}
