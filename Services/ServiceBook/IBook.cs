using BeamX_Task.Models;

namespace BeamX_Task.Services.ServiceBook
{
    public interface IBook
    {
        public string Save(Book book,int AuthorId);
        public string Delete(int id);

        public Book GetBookById(int id);
        public List<Book> GetAllBooks();
        public string Update(Book book);
    }
}
