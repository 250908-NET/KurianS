using System.Collections.Generic;
using System.Threading.Tasks;
using BookAuthor.Models;

namespace BookAuthor.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);

        // Extra: get Book with Author and Categories
        Task<Book?> GetByIdWithDetailsAsync(int id);

        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveChangesAsync();
    }
}
