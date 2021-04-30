using System;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        public string Login { get; set; }
        [MinLength(4)]
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public char Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
