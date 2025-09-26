namespace BookAuthor.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }       // Book ID
        public string Title { get; set; } // Book title
        public int AuthorId { get; set; } // Link to author
    }
}
