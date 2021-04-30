using Microsoft.AspNetCore.Identity;
using System;


namespace FinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public char Gender { get; set; }
    }
}
