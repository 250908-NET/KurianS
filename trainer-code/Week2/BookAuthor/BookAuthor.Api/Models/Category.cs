
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // <-- needed for [ForeignKey]
using System.Collections.Generic;


namespace BookAuthor.Models
{
    public class Category

    {
        //fields
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }

        // Many-to-Many relationship with Book (book -categories)


        public List<BookCategory> BookCategories { get; set; } = new();

    }
}