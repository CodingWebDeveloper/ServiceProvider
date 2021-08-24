using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public class ImagesService : IImagesService
    {
        private readonly HttpClient httpClient;

        public ImagesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateAsync(UploadImagesInputModel inputModel)
        {
            await this.httpClient.PostAsJsonAsync("api/images", inputModel);
        }
    }
}
