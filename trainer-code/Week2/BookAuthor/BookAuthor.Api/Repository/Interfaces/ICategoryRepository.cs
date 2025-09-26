using System.Collections.Generic;
using System.Threading.Tasks;
using BookAuthor.Models;
           // for AuthorService, BookService, CategoryService


namespace BookAuthor.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);

        // Extra: get Category with Books
        Task<Category?> GetByIdWithBooksAsync(int id);

        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task SaveChangesAsync();
    }
}
