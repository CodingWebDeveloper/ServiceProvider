using ServiceProvider.Shared.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly HttpClient httpClient;

        public CategoriesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateAsync(CreateCategoryInputModel inputModel)
        {
            await this.httpClient.PostAsJsonAsync("api/categories", inputModel);
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.httpClient.GetFromJsonAsync<IEnumerable<T>>("api/categories");
        }
    }
}
