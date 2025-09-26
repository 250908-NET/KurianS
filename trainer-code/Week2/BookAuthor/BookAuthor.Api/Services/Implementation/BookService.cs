using BookAuthor.Models;
using BookAuthor.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAuthor.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Book>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Book?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<Book> CreateAsync(Book book)
        {
            await _repo.AddAsync(book);
            await _repo.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            await _repo.UpdateAsync(book);
            await _repo.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
                return false;

            await _repo.DeleteAsync(book);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}