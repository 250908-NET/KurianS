using BookAuthor.Models;


namespace BookAuthor.Services

{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}