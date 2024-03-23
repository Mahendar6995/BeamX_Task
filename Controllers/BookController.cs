using BeamX_Task.Models;
using BeamX_Task.Services;
using BeamX_Task.Services.ServiceBook;
using BeamX_Task.ViewModels;

using Microsoft.AspNetCore.Mvc;

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
            ViewBag.AuthorsList = authorservice.GetAllAuthors();
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookVM bookVM,int AuthorId)
        {
            Book newBook = new Book();
            newBook.Title = bookVM.Title;
            newBook.Description = bookVM.Description;
            TempData["Message"]=bookservice.Save(newBook,AuthorId);
            return RedirectToAction("AddBook");
        }

        [HttpGet]
        public IActionResult ShowBookDetails()
        {
            List<BookAuthorVm> bookAuthorVms = bookservice.GetBooksWithAuthor();

            ViewBag.BookAuthorsList = bookAuthorVms.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book=bookservice.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            TempData["Message"] = bookservice.Update(book);
            return RedirectToAction();

        }

    }
}
