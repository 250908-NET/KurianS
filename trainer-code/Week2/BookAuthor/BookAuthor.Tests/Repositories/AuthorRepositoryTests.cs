using Xunit;
using BookAuthor.Models;
using System.Threading.Tasks;
using BookAuthor.Repositories.Implementation;
using BookAuthor.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookAuthor.Tests.Repositories
{
    public class AuthorRepositoryTests
    {
        private BookAuthorDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<BookAuthorDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            return new BookAuthorDbContext(options);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllAuthors()
        {
            using var context = GetInMemoryDbContext();

            context.Authors.AddRange(new List<Author>
            {
                new Author { Id = 1, Name = "Author 1" },
                new Author { Id = 2, Name = "Author 2" }
            });
            await context.SaveChangesAsync();

            var repo = new AuthorRepository(context);

            var result = await repo.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        // Other tests ...
    }
}
