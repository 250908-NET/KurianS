using BookAuthor.Models;


namespace BookAuthor.Services

{
    public interface ICategoryService
    {
          Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}