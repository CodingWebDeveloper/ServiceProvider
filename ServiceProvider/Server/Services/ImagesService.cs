using ServiceProvider.Server.Data;
using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class ImagesService : IImagesService
    {
        private readonly ApplicationDbContext dbContext;

        public ImagesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task CreateAsync(CreateImagesInputModel inputModel)
        {
            throw new NotImplementedException();
        }
    }
}
