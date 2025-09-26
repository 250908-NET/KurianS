using BookAuthor.Models;
using BookAuthor.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace BookAuthor.Services

{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task<AuthorDto> CreateAsync(AuthorDto dto);
        Task<AuthorDto> UpdateAsync(AuthorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}