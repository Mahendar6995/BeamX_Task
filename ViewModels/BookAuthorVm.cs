namespace BeamX_Task.ViewModels
{
    public class BookAuthorVm
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { set; get; }
        public string AuthorName { set; get; }
    }
}
