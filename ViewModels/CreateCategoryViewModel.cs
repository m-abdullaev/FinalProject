using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
