
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthor.Models
{

    // to create a book

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Range(0, 9999)]
        public int YearPublished { get; set; }
        [Required]
        public int AuthorId { get; set; }    // one -many to relation
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        public List<BookCategory> BookCategories { get; set; } = new(); 
        
            [NotMapped]
    public IEnumerable<Category> Categories => BookCategories.Select(bc => bc.Category);
} //many to many(book -category)
    }

