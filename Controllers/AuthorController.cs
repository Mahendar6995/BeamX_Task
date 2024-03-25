using BeamX_Task.Models;
using BeamX_Task.Services;
using BeamX_Task.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeamX_Task.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthor authorservice;

        public AuthorController(IAuthor authorservice)
        {
            this.authorservice = authorservice;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorVM authorVM)
        {
            if(ModelState.IsValid)
            {
                Author newauthor = new Author();
                newauthor.AuthorName = authorVM.AuthorName;
                TempData["Message"]=authorservice.Save(newauthor);
            }
            return RedirectToAction("AddAuthor");
        }

        [HttpGet]
        public ActionResult GetAllAuthors()
        {
            List<Author> authors=authorservice.GetAllAuthors();
            ViewBag.Authors = authors;
            return View();
        }
    }
}
