
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
