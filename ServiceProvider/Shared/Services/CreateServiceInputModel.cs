namespace ServiceProvider.Shared.Services
{
    using ServiceProvider.Shared.Categories;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
