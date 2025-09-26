
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAuthor.Models;

namespace BookAuthor.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);

       
        // Extra: fetch Author with Profile
        Task<Author?> GetByIdWithProfileAsync(int id);

        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(Author author);
        Task SaveChangesAsync();
    }
}

