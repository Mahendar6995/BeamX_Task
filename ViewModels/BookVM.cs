using BeamX_Task.Models;
using System.ComponentModel.DataAnnotations;

namespace BeamX_Task.ViewModels
{
    public class BookVM
    {
        public int BookId { set; get;}

        [Required(ErrorMessage ="Title cannot be empty!!!")]
        [MinLength(5)]
        public string? Title { get; set; }
        [Required (ErrorMessage ="Description cannot be empty!!!")]
        [MinLength(5)]
        public string? Description { get; set; }

        public int AuthorId { set; get; }

        // Navigation property
        public ICollection<BookAuthorVM> BookAuthors { get; set; }
    }
}
