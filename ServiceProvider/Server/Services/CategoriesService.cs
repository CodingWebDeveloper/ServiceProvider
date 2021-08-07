using AutoMapper;
using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CategoriesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateCategoryInputModel inputModel)
        {
            Category category = new Category()
            {
                Name = inputModel.Name,
            };

            await this.dbContext.Categories.AddAsync(category);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.mapper.ProjectTo<T>(this.dbContext.Categories);
        }
    }
}
