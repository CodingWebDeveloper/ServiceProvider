using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceProvider.Shared.Categories;
using ServiceProvider.Shared.Packages;
using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Services
{
    public class CreateServiceInputModel
    {
        [Required]
        [MinLength(20)]
        public string Title { get; set; }

        public string UserId { get; set; }

        [Required]
        [MinLength(150)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> ListItems { get; set; }
    }
}
