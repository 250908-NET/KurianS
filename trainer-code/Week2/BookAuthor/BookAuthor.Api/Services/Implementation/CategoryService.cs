using BookAuthor.Models;
using BookAuthor.Repositories.Interfaces; // for ICategoryRepository
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAuthor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Category>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Category?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<Category> CreateAsync(Category category)
        {
            await _repo.AddAsync(category);
            await _repo.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            await _repo.UpdateAsync(category);
            await _repo.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
                return false;

            await _repo.DeleteAsync(category);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}