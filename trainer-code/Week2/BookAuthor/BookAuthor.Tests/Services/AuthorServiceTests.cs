using Xunit;
using Moq;
using BookAuthor.Repositories.Interfaces;
using BookAuthor.Models;
using BookAuthor.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using BookAuthor.DTOs;

namespace BookAuthor.Tests.Services
{
    public class AuthorServiceTests
    {
        [Fact]
        public async Task GetAllAuthors_ShouldReturnAuthors()
        {
            // Arrange: create fake authors
            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "Author 1"},
                new Author { Id = 2, Name = "Author 2"}
            };

            // Mock the repository
            var mockRepo = new Mock<IAuthorRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(authors);

            // Inject mock into service
            var service = new AuthorService(mockRepo.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be("Author 1");
        }
    }
}
