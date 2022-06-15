using ServiceProvider.Shared.Images;
using ServiceProvider.Shared.PackageModels;
using ServiceProvider.Shared.Reviews;
using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public class ServicesService : IServicesService
    {
        private readonly HttpClient httpClient;
        private string errorMessage;

        public ServicesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> CreateAsync(CreateServiceInputModel inputModel)
        {
            using var httpResponse = await this.httpClient.PostAsJsonAsync("api/services/create-new", inputModel); 

            if(!httpResponse.IsSuccessStatusCode)
            {
                this.errorMessage = httpResponse.ReasonPhrase;
                Console.WriteLine($"There was an error! {this.errorMessage}");
            }

            return await httpResponse.Content.ReadFromJsonAsync<int>();
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.httpClient.GetFromJsonAsync<IEnumerable<T>>("api/services/all");
        }

        public async Task<IEnumerable<T>> GetAllByUserId<T>()
        {
            return await this.httpClient.GetFromJsonAsync<IEnumerable<T>>("api/services/created-by-user");
        }

        public async Task<T> GetById<T>(int serviceId)
        {
            return await this.httpClient.GetFromJsonAsync<T>($"api/services/info/{serviceId}");
        }

        public async Task<double> GetStartingPrice(int serviceId)
        {
            return await this.httpClient.GetFromJsonAsync<double>($"api/services/price/{serviceId}");
        }

        public async Task<int> GetUnfinishedOrdersBy(int serviceId)
        {
            return await this.httpClient.GetFromJsonAsync<int>($"api/services/unfinished-orders/{serviceId}");
        }

        public async Task PublishServiceBy(int serviceId)
        {
            await this.httpClient.PostAsJsonAsync($"api/services/publish", serviceId);
        }
    }
}
