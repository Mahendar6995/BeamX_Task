using BeamX_Task.Context;
using BeamX_Task.Models;
using BeamX_Task.ViewModels;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BeamX_Task.Services.ServiceBook
{
    public class BookService : IBook
    {
        private MyDbContext ctx;

        public BookService(MyDbContext ctx)
        {
            this.ctx = ctx;
        }
        public string Delete(int id)
        {
            Book deletebook=GetBookById(id);    
            if(deletebook!=null)
            {
                ctx.Books.Remove(deletebook);
                int rowsupdated = ctx.SaveChanges();
                if (rowsupdated > 0)
                {
                    return "Data Saved Successfully!!!";
                }
            }
            return "Something went Wrong!!!";


        }


        public List<BookAuthorVm> GetBooksWithAuthor()
        {
            List<BookAuthorVm> bookAuthorVms= new List<BookAuthorVm>();

            //foreach(var book in ctx.Books)
            //{
            //    var bookauthor = new BookAuthorVm()
            //    {
            //        BookId = book.BookId,
            //        Description = book.Description,
            //        Title = book.Title
            //    };
            //    if (book.Authors != null)
            //    {
            //        foreach (var author in book.Authors)
            //        {
            //            bookauthor.AuthorId = author.AuthorId;
            //            bookauthor.AuthorName = author.AuthorName;
            //        }
            //    }
            //    bookAuthorVms.Add(bookauthor);
            //}
            return bookAuthorVms;
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

        public string Save(Book book,int AuthorId)
        {
            Author author = ctx.Authors.Where(val=>val.AuthorId==AuthorId).FirstOrDefault();
            //book.Authors = new List<Author>();
            //book.Authors.Add(author);
            ctx.Books.Add(book);
            int rowsupdated=ctx.SaveChanges();
            if(rowsupdated>0)
            {
                return "Data Saved Successfully!!!";
            }
            return "Something went Wrong!!!";
        }

        public string Update(Book book)
        {
            ctx.Books.Add(book);
            int rowsupdated=ctx.SaveChanges();
            if (rowsupdated > 0)
            {
                return "Data Updated Successfully!!!";
            }
            return "Something went Wrong!!!";
        }
    }
}
