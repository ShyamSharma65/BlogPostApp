using BlogPost.API.Models.Domain;

namespace BlogPost.API.Repository.Interface
{
    public interface ICategoriesRepository
    {
        Task<int> CreateAsync(Category category);
        Task<int> UpdateAsync(Category category);
    }
}
