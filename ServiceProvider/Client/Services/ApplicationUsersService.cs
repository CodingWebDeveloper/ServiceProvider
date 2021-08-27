using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly HttpClient httpClient;

        public ApplicationUsersService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<T> GetById<T>()
        {
            return await this.httpClient.GetFromJsonAsync<T>("api/application-users");
        }
    }
}
