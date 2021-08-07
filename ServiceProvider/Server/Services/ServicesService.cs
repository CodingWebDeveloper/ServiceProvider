using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class ServicesService : IServicesService
    {
        private readonly ApplicationDbContext dbContext;

        public ServicesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(CreateServiceInputModel inputModel)
        {
            Service service = new Service()
            {
                Title = inputModel.Title,
                CategoryId = inputModel.CategoryId,
                Description = inputModel.Description,
                UserId = inputModel.UserId,
            };

            await this.dbContext.Services.AddAsync(service);
            await this.dbContext.SaveChangesAsync();

            return service.Id;
        }
    }
}
