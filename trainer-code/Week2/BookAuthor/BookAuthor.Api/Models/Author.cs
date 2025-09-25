
namespace BookAuthor.Api.Models

// to create a author

    public class Author
    { 
        public int Id {get; set;}
        public string Name{ get; set;}
        public AuthorProfile Profile {get; set;}    // one -one to relationship
        public List <Book> Books {get; set;} = new();  //one to many
    }


