using BlogPost.API.Data;
using BlogPost.API.Models.Domain;
using BlogPost.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.API.Repository.Implementation
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoriesRepository> _logger; 
        public CategoriesRepository(ApplicationDbContext context, ILogger<CategoriesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> CreateAsync(Category category)
        {
            try
            {
               // _logger.LogTrace();
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public async Task<int> UpdateAsync(Category category)
        {
            try
            {

                var categoryById = await _context.Categories.Where(c => c.Id == category.Id).FirstOrDefaultAsync();
                if (categoryById != null) {
                    categoryById.Name = category.Name;
                    categoryById.UrlHandle = category.UrlHandle;
                    await _context.Categories.AddAsync(categoryById);
                    await _context.SaveChangesAsync();
                    
                }
            }
            catch (Exception ex)
            {   
                return 0;
            }
            return 1;
           
        }
    }
}
