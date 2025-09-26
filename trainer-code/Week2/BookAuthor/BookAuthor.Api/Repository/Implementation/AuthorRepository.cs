using BookAuthor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAuthor.Data;
using BookAuthor.Repositories.Interfaces;

namespace BookAuthor.Repositories.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookAuthorDbContext _context;

        public AuthorRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        // Get all authors
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        // Get author by ID
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        // Get author with Profile
        public async Task<Author?> GetByIdWithProfileAsync(int id)
        {
            return await _context.Authors
                .Include(a => a.Profile)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Add new author
        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
        }

        // Update existing author
        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
        }

        // Delete author
        public async Task DeleteAsync(Author author)
        {
            _context.Authors.Remove(author);
        }

        // Save changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}