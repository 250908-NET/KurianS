
using Microsoft.EntityFrameworkCore;
using BookAuthor.Data;
using BookAuthor.Models;
using Serilog;
using BookAuthor.Services;
using BookAuthor.Repositories;
using BookAuthor.Repositories.Interfaces;
using BookAuthor.Repositories.Implementation;
using BookAuthor.DTOs;



var builder = WebApplication.CreateBuilder(args);

string CS = File.ReadAllText("../connection_string.env");

// Add services to the container.

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookAuthorDbContext>(options => options.UseSqlServer(CS));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();   // read from appsettings.json
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
Log.Information("Application starting...");


app.MapGet("/", () =>
{
    Log.Information("Hello world endpoint hit");
    return "Hello world";
});

// GET all authors
app.MapGet("/authors", async (IAuthorService service) =>
{
    var authors = await service.GetAllAsync();
    return Results.Ok(authors);
});

// GET author by ID
app.MapGet("/authors/{id}", async (int id, IAuthorService service) =>
{
    var author = await service.GetByIdAsync(id);
    return author != null ? Results.Ok(author) : Results.NotFound();
});

// POST: Create new author
app.MapPost("/authors", async (AuthorDto dto, IAuthorService service) =>
{
    var createdAuthor = await service.CreateAsync(dto);
    return Results.Created($"/authors/{createdAuthor.Id}", createdAuthor);
});

// PUT: Update existing author
app.MapPut("/authors/{id}", async (int id, AuthorDto dto, IAuthorService service) =>
{
     dto.Id = id; // Set the ID
    await service.UpdateAsync(dto);
    return Results.NoContent(); 
});

// DELETE: Remove author
app.MapDelete("/authors/{id}", async (int id, IAuthorService service) =>
{
    var deleted = await service.DeleteAsync(id);
    return deleted ? Results.NoContent() : Results.NotFound();
});


// POST: Create new book
app.MapPost("/books", async (Book book, IBookService service) =>
{
    var createdBook = await service.CreateAsync(book);
    return Results.Created($"/books/{createdBook.Id}", createdBook);
});

// PUT: Update existing book
app.MapPut("/books/{id}", async (int id, Book updatedBook, IBookService service) =>
{
    updatedBook.Id = id; // set the ID from URL
    await service.UpdateAsync(updatedBook);
    return Results.NoContent();
});

// DELETE: Remove book
app.MapDelete("/books/{id}", async (int id, IBookService service) =>
{
    var deleted = await service.DeleteAsync(id);
    return deleted ? Results.NoContent() : Results.NotFound();
});

// Category endpoints

// CREATE Category
app.MapPost("/categories", async (Category category, ICategoryRepository repo) =>
{
    await repo.AddAsync(category);
    await repo.SaveChangesAsync();
    return Results.Created($"/categories/{category.Id}", category); // return category, not "created"
});

// UPDATE Category
app.MapPut("/categories/{id}", async (int id, Category updatedCategory, ICategoryRepository repo) =>
{
    var existing = await repo.GetByIdAsync(id);
    if (existing == null)
        return Results.NotFound();

    existing.Name = updatedCategory.Name;
    await repo.UpdateAsync(existing);
    await repo.SaveChangesAsync();

    return Results.Ok(existing); //  return updated entity
});
// DELETE Category

app.MapDelete("/categories/{id}", async (int id, ICategoryRepository repo) =>
{
    var category = await repo.GetByIdAsync(id);
    if (category is null) return Results.NotFound();

    await repo.DeleteAsync(category);
    await repo.SaveChangesAsync();

    return Results.NoContent();
});

// for authorprofiles

// POST /authorprofiles
app.MapPost("/authorprofiles", async (AuthorProfile profile, BookAuthorDbContext db) =>
{
    // Check if the author exists
    var author = await db.Authors.FindAsync(profile.AuthorId);
    if (author == null)
        return Results.NotFound($"Author with ID {profile.AuthorId} not found.");

    // Add profile
    db.AuthorProfiles.Add(profile);
    await db.SaveChangesAsync();

    return Results.Created($"/authorprofiles/{profile.Id}", profile);
});


app.MapGet("/books/{bookId}", async (int bookId, BookAuthorDbContext db) =>
{
    var book = await db.Books
                       .Include(b => b.BookCategories)
                           .ThenInclude(bc => bc.Category)
                       .FirstOrDefaultAsync(b => b.Id == bookId);

    if (book == null) return Results.NotFound();

    return Results.Ok(new 
    {
        book.Id,
        book.Title,
        book.YearPublished,
        Categories = book.BookCategories.Select(bc => new { bc.Category.Id, bc.Category.Name })
    });
});



app.Run();

