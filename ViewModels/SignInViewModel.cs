using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
