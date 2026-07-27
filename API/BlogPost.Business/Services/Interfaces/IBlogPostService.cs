using BlogPost.SharedLibrary.Models;

namespace BlogPost.BusinessLayer.Services.Interfaces
{
    public interface IBlogPostService
    {
        Task<List<BlogPostDto>> GetAllAsync();
        Task<BlogPostDto?> GetByIdAsync(long id);
        Task<BlogPostDto> SaveAsync(BlogPostDto blogPost);
        Task<BlogPostDto?> UpdateAsync(long id, BlogPostDto blogPost);
        Task<bool> DeleteAsync(long id);
    }
}
