using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public interface IImagesService
    {
        public Task CreateAsync(UploadImagesInputModel inputModel);
    }
}
