
namespace ServiceProvider.Server.Services
{
    using ServiceProvider.Server.Data;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Services;
    using ServiceProvider.Server.Models.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using System;

    public class ServicesService : IServicesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ServicesService(
            ApplicationDbContext dbContext,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int CalculateRatingBy(int serviceId)
        {
            IEnumerable<Review> reviews = this.dbContext.Reviews;
            int rating = (int)Math.Round(reviews.Sum(r => r.Rate) / reviews.Count());
            return rating;
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

        public IEnumerable<T> GetAll<T>()
        {
            return this.mapper.ProjectTo<T>(this.dbContext.Services.Where(s => s.IsPublished));
        }

        public IEnumerable<T> GetAllBy<T>(string userId)
        {
            return this.mapper.ProjectTo<T>(this.dbContext.Services.Where(s => s.UserId == userId));
        }

        public T GetById<T>(int serviceId)
        {
            return this.mapper.ProjectTo<T>(this.dbContext.Services.Where(s=>s.Id == serviceId)).FirstOrDefault();
        }

        public decimal GetStartingPrice(int serviceId)
        {
            decimal price = 0;
            var service = this.dbContext.Services.Select(x => new
            {
                Id = x.Id,
                Packages = x.Packages,
            }).FirstOrDefault(s => s.Id == serviceId);

            if (service.Packages.Any()) 
            {
                price = this.dbContext.Services
                .FirstOrDefault(s => s.Id == serviceId).Packages
                .FirstOrDefault(c => c.PackageType == TypeOfPackage.Basic).Price;
            }

            return price;
        }

        public int GetUnfinishedOrdersBy(int serviceId)
        {
            return this.dbContext.Orders
                .Where(o => o.FinishedDate != null && o.Package.ServiceId == serviceId)
                .Count();
        }

        public async Task PublishServiceBy(int serviceId)
        {
            Service service = await this.dbContext.Services.FindAsync(serviceId);

            service.IsPublished = true;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
