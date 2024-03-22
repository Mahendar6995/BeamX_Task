using BeamX_Task.Models;

namespace BeamX_Task.Services.ServiceBook
{
    public interface IBook
    {
        public void Save(Book book);
        public void Delete(int id);

        public Book GetBookById(int id);
        public List<Book> GetAllBooks();
        public void Update(Book book);
    }
}
