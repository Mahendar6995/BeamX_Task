using System.ComponentModel.DataAnnotations;

namespace BeamX_Task.ViewModels
{
    public class AuthorVM
    {
        [Required(ErrorMessage ="Author Name cannot be Empty!!!")]
        public string? AuthorName { set; get; }
    }
}
