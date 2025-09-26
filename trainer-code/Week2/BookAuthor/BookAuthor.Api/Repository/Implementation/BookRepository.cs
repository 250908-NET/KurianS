using BookAuthor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAuthor.Data;
using BookAuthor.Repositories.Interfaces;

namespace BookAuthor.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly BookAuthorDbContext _context;

        public BookRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        // Get all books
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        // Get book by ID
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        // Get book with Author and Categories
        public async Task<Book?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author) // include author
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category) // include categories
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // Add new book
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        // Update existing book
        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
        }

        // Delete book
        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
        }

        // Save changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
