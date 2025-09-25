
using BookAuthor.Models;
using Microsoft.EntityFrameworkCore;

// to corelate with my namespace

namespace BookAuthor.Data;

public class BookAuthorDbContext : DbContext
{
    // fields: for creating tables foir models in the db

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AuthorProfile> AuthorProfiles { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }


    // methods: need aconstructor, 

    public BookAuthorDbContext(DbContextOptions<BookAuthorDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Composite key for BookCategory
    modelBuilder.Entity<BookCategory>()
        .HasKey(bc => new { bc.BookId, bc.CategoryId });

    // Many-to-many relationships
    modelBuilder.Entity<BookCategory>()
        .HasOne(bc => bc.Book)
        .WithMany(b => b.BookCategories)
        .HasForeignKey(bc => bc.BookId);

    modelBuilder.Entity<BookCategory>()
        .HasOne(bc => bc.Category)
        .WithMany(c => c.BookCategories)
        .HasForeignKey(bc => bc.CategoryId);

    // One-to-one Author-AuthorProfile
    modelBuilder.Entity<Author>()
        .HasOne(a => a.Profile)
        .WithOne(p => p.Author)
        .HasForeignKey<AuthorProfile>(p => p.AuthorId);
}
    }

