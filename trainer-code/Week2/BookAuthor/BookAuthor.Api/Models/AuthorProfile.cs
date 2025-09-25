
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookAuthor.Models
{
    public class AuthorProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Bio { get; set; }

        // Foreign key to Author
        public int AuthorId { get; set; }

        // Navigation property
        public Author ? Author { get; set; }
    }
}
