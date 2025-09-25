

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; //// Keep it, used for DbSet or EF Core features
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAuthor.Models
{
    public class BookCategory
    {
        public int BookId { get; set; }


        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        public int CategoryId { get; set; }
         [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
