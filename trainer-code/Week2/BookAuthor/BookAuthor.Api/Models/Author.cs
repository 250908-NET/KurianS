
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; //// Keep it, used for DbSet or EF Core features
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;


namespace BookAuthor.Models
{

    // to create a author

    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public AuthorProfile ?Profile { get; set; }    // one -one to relationship
        public List<Book> Books { get; set; } = new();  //one to many
    }
}



