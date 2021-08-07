using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface IImagesService
    {
        Task CreateAsync(CreateImagesInputModel inputModel);
    }
}
