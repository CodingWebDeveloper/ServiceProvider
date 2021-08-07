using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
            using var httpResponse = await this.httpClient.PostAsJsonAsync("api/services", inputModel); 

            if(!httpResponse.IsSuccessStatusCode)
            {
                this.errorMessage = httpResponse.ReasonPhrase;
                Console.WriteLine($"There was an error! {this.errorMessage}");
            }

            return await httpResponse.Content.ReadFromJsonAsync<int>();
        }
    }
}
