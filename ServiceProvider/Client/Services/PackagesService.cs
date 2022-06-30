using ServiceProvider.Shared.PackageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly HttpClient httpClient;

        public PackagesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateAsync(CreatePackageInputModel inputModel)
        {
            await this.httpClient.PostAsJsonAsync("api/packages/create", inputModel);
        }

        public async Task<IEnumerable<T>> GetAllBy<T>(int serviceId)
        {
            return await this.httpClient.GetFromJsonAsync<IEnumerable<T>>($"api/packages/by-service-id/{serviceId}");
        }
    }
}
