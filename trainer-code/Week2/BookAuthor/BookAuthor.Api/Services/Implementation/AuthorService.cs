using BookAuthor.Models;
using BookAuthor.Repositories.Interfaces; // make sure you have this namespace for IAuthorRepository
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAuthor.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repo;

        public AuthorService(IAuthorRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Author>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Author?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<Author> CreateAsync(Author author)
        {
            await _repo.AddAsync(author);
            await _repo.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            await _repo.UpdateAsync(author);
            await _repo.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _repo.GetByIdAsync(id);
            if (author == null)
                return false;

            await _repo.DeleteAsync(author);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
