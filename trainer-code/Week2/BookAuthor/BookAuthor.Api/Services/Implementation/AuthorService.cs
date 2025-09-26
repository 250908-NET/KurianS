
using BookAuthor.DTOs;
using BookAuthor.Models;
using BookAuthor.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        // Map Author entity -> DTO
        private AuthorDto MapToDto(Author author) => new AuthorDto
        {
            Id = author.Id,
            Name = author.Name,
            
        };

        // Map DTO -> Author entity
        private Author MapToEntity(AuthorDto dto) => new Author
        {
            Id = dto.Id,
            Name = dto.Name,
        
        };

        // Get all authors as DTOs
        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _repo.GetAllAsync();
            return authors.Select(MapToDto);
        }

        // Get author by Id as DTO
        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var author = await _repo.GetByIdAsync(id);
            return author == null ? null : MapToDto(author);
        }

        // Create author from DTO
        public async Task<AuthorDto> CreateAsync(AuthorDto dto)
        {
            var author = MapToEntity(dto);
            await _repo.AddAsync(author);
            await _repo.SaveChangesAsync();
            return MapToDto(author);
        }

        // Update author from DTO
        public async Task<AuthorDto> UpdateAsync(AuthorDto dto)
        {
            var author = MapToEntity(dto);
            await _repo.UpdateAsync(author);
            await _repo.SaveChangesAsync();
            return MapToDto(author);
        }

        // Delete author
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

