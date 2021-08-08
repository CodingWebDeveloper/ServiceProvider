using AutoMapper;
using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Services;
namespace ServiceProvider.Server.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ServicesService : IServicesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ServicesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateServiceInputModel inputModel)
        {
            Service service = new()
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

        public IEnumerable<T> GetAllBy<T>(string userId)
        {
            return this.mapper.ProjectTo<T>(this.dbContext.Services.Where(s => s.UserId == userId));
        }
    }
}
