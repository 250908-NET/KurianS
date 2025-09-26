using BookAuthor.Models;


namespace BookAuthor.Services

{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> CreateAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        Task<bool> DeleteAsync(int id);
    }
}