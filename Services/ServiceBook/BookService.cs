using BeamX_Task.Context;
using BeamX_Task.Models;

namespace BeamX_Task.Services.ServiceBook
{
    public class BookService : IBook
    {
        private MyDbContext ctx;

        public BookService(MyDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Delete(int id)
        {
            Book deletebook=GetBookById(id);    
            if(deletebook!=null)
            {
                ctx.Books.Remove(deletebook);
                ctx.SaveChanges();
            }
            
        }

        public List<Book> GetAllBooks()
        {
            List<Book> BooksList = ctx.Books.ToList();
            return BooksList;
        }

        public Book GetBookById(int id)
        {
            Book book = ctx.Books.Where(val => val.BookId == id).FirstOrDefault();
            return book;
        }

        public void Save(Book book)
        {

        }

        public void Update(Book book)
        {
            ctx.Books.Add(book);
            ctx.SaveChanges();
        }
    }
}
