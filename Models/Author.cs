namespace BeamX_Task.Models
{
    public class Author
    {
        public int AuthorId { set; get; }
        public string AuthorName { set; get; }


        // Navigation Property

        public ICollection<Book> Books { set; get; }
    }
}
