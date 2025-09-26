using BookAuthor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAuthor.Data;

namespace BookAuthor.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookAuthorDbContext _context;

        public CategoryRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        // Get all categories
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        // Get category by ID
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        // Get category with related books
        public async Task<Category?> GetByIdWithBooksAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book) // include books
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Add new category
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        // Update existing category
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
        }

        // Delete category
        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
        }

        // Save changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
