namespace BeamX_Task.Models
{
    public class BookAuthor
    {
        public int Id { get; set; } 

        public int BookId { set; get; }
        public Book Book { get; set; }

        public int AuthorId { set; get; }
        public Author Author { set; get; }
    }
}
