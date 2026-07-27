using System.Data;
using BlogPost.API.Data;
using BlogPost.API.Repository.Interface;
using BlogPost.SharedLibrary.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.API.Repository.Implementation
{
    public class BlogPostsRepository : IBlogPostsRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlogPostDto>> GetAllAsync()
        {
            return await _context.BlogPosts
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new BlogPostDto
                {
                    Id = x.Id,
                    BlogPostName = x.BlogPostName,
                    BlogPostDescription = x.BlogPostDescription,
                    BlogPostContent = x.BlogPostContent,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Comments = x.Comments,
                    IsPublished = x.IsPublished,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedOn = x.ModifiedOn
                })
                .ToListAsync();
        }

        public async Task<BlogPostDto?> GetByIdAsync(long id)
        {
            return await _context.BlogPosts
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new BlogPostDto
                {
                    Id = x.Id,
                    BlogPostName = x.BlogPostName,
                    BlogPostDescription = x.BlogPostDescription,
                    BlogPostContent = x.BlogPostContent,
                    FeaturedImageUrl = x.FeaturedImageUrl,
                    Comments = x.Comments,
                    IsPublished = x.IsPublished,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    ModifiedBy = x.ModifiedBy,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn
                })
                .FirstOrDefaultAsync();
        }

        public async Task<BlogPostDto> SaveAsync(BlogPostDto blogPost)
        {
            if (blogPost is null)
            {
                throw new ArgumentNullException(nameof(blogPost));
            }

            var idParameter = new SqlParameter("@Id", blogPost.Id)
            {
                Direction = ParameterDirection.InputOutput
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.USPSaveBlogPost @Id OUTPUT, @BlogPostName, @BlogPostDescription, @BlogPostContent, @FeaturedImageUrl, @Comments, @IsPublished, @IsActive, @CreatedBy, @CreatedOn, @ModifiedBy, @ModifiedOn",
                idParameter,
                new SqlParameter("@BlogPostName", blogPost.BlogPostName ?? string.Empty),
                new SqlParameter("@BlogPostDescription", (object?)blogPost.BlogPostDescription ?? DBNull.Value),
                new SqlParameter("@BlogPostContent", blogPost.BlogPostContent ?? string.Empty),
                new SqlParameter("@FeaturedImageUrl", (object?)blogPost.FeaturedImageUrl ?? DBNull.Value),
                new SqlParameter("@Comments", (object?)blogPost.Comments ?? DBNull.Value),
                new SqlParameter("@IsPublished", blogPost.IsPublished),
                new SqlParameter("@IsActive", blogPost.IsActive),
                new SqlParameter("@CreatedBy", (object?)blogPost.CreatedBy ?? DBNull.Value),
                new SqlParameter("@CreatedOn", blogPost.CreatedOn),
                new SqlParameter("@ModifiedBy", (object?)blogPost.ModifiedBy ?? DBNull.Value),
                new SqlParameter("@ModifiedOn", blogPost.ModifiedOn));

            var savedId = idParameter.Value is DBNull or null ? blogPost.Id : Convert.ToInt64(idParameter.Value);
            blogPost.Id = savedId;

            var savedBlogPost = await GetByIdAsync(savedId);
            return savedBlogPost ?? blogPost;
        }

        public async Task<BlogPostDto?> UpdateAsync(long id, BlogPostDto blogPost)
        {
            var existingBlogPost = await _context.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBlogPost is null)
            {
                return null;
            }

            existingBlogPost.BlogPostName = blogPost.BlogPostName;
            existingBlogPost.BlogPostDescription = blogPost.BlogPostDescription;
            existingBlogPost.BlogPostContent = blogPost.BlogPostContent;
            existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
            existingBlogPost.Comments = blogPost.Comments;
            existingBlogPost.IsPublished = blogPost.IsPublished;
            existingBlogPost.IsActive = blogPost.IsActive;
            existingBlogPost.ModifiedBy = blogPost.ModifiedBy;
            existingBlogPost.ModifiedOn = blogPost.ModifiedOn;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existingBlogPost = await _context.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBlogPost is null)
            {
                return false;
            }

            _context.BlogPosts.Remove(existingBlogPost);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
