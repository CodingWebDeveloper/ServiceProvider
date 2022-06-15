using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly HttpClient httpClient;

        public SkillsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Create(AddSkillInputModel inputModel)
        {
            await this.httpClient.PostAsJsonAsync("api/skills/create", inputModel);
        }

        public async Task<IEnumerable<T>> GetAllByUser<T>()
        {
            return await this.httpClient.GetFromJsonAsync<IEnumerable<T>>("api/skills/userSkills");
        }
    }
}
