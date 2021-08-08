using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public class RequirementsService : IRequirementsService
    {
        private readonly HttpClient httpClient;
        private const string REQUIREMENTS_HREF = "api/requirements";


        public RequirementsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateAsync(CreateRequirementInputModel inputModel)
        {
            await this.httpClient.PostAsJsonAsync(REQUIREMENTS_HREF, inputModel);
        }

        public async Task DeleteAsync(int requirementId)
        {
            await this.httpClient.DeleteAsync($"{REQUIREMENTS_HREF}/{requirementId}");
        }

        public async Task<IEnumerable<T>> GetAllBy<T>(int serviceId)
        {
            return await this.httpClient.GetFromJsonAsync<IEnumerable<T>>($"{REQUIREMENTS_HREF}/{serviceId}");
        }

        public async Task UpdateAsync(EditRequirementInputModel inputModel)
        {
           await this.httpClient.PutAsJsonAsync(REQUIREMENTS_HREF, inputModel);
        }

        public async Task<T> GetAsync<T>(int requirementId)
        {
            return  await this.httpClient.GetFromJsonAsync<T>($"{REQUIREMENTS_HREF}/requirement/{requirementId}");
        }
    }
}
