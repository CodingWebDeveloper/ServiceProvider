using ServiceProvider.Shared.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface ICategoriesService
    {
        Task CreateAsync(CreateCategoryInputModel inputModel);

        IEnumerable<T> GetAll<T>();
    }
}
