using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Services;
using ServiceProvider.Shared.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryInputModel inputModel)
        {
            await this.categoriesService.CreateAsync(inputModel);
            return this.Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Ok(this.categoriesService.GetAll<CategoryViewModel>());
        }
    }
}
