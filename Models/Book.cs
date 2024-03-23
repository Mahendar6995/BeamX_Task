namespace BeamX_Task.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Navigation proprty

        public ICollection<BookAuthor> BookAuthors { get; set;}
    }
}
