using ServiceProvider.Shared.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public interface ICategoriesService
    {
        Task CreateAsync(CreateCategoryInputModel inputModel);

        Task<IEnumerable<T>> GetAll<T>();
    }
}
