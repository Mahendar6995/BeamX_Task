using BeamX_Task.Models;
using BeamX_Task.Services;
using BeamX_Task.Services.ServiceBook;
using BeamX_Task.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeamX_Task.Controllers
{
    public class BookController : Controller
    {
        private IBook bookservice;
        private IAuthor authorservice;
        public BookController(IBook bookservice,IAuthor authorservice)
        {
            this.bookservice = bookservice;
            this.authorservice = authorservice; 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            List<Author> authors = authorservice.GetAllAuthors();
            ViewBag.AuthorsList = authors;
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookVM bookVM)
        {
            Book newBook;
            List<Author> authors = authorservice.GetAllAuthors();
            ViewBag.AuthorsList = authors;
            if (ModelState.IsValid)
            {
                newBook= new Book();
                newBook.Title = bookVM.Title;
                newBook.Description = bookVM.Description;
                int AuthorId = bookVM.AuthorId;
                TempData["Message"] = bookservice.Save(newBook, AuthorId);
                return RedirectToAction("AddBook");
            }
            return View("AddBook",bookVM);
        }

        [HttpGet]
        public IActionResult ShowBookDetails()
        {
            List<Book> books = bookservice.GetAllBooks();
            ViewBag.BookAuthorsList = books.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = bookservice.GetBookById(id);
            ViewBag.AuthorsList = authorservice.GetAllAuthors();
            return View(book);
        }
        
        [HttpPost]
        public IActionResult Edit(Book book,int AuthorId)
        {
            if (ModelState.IsValid)
            {

                TempData["Message"] = bookservice.Update(book, AuthorId);
                return RedirectToAction("ShowBookDetails");
            }
            else return RedirectToAction("Edit");

        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            TempData["Message"] = bookservice.Delete(id);
            return RedirectToAction("ShowBookDetails");
        }

        [HttpGet]
        public IActionResult GetAllBooks() 
        {
            ViewBag.Books = bookservice.GetAllBooks();  
            return View();
        }

    }
}
