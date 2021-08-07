using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Server.Models.Enums;
using ServiceProvider.Shared.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly ApplicationDbContext dbContext;

        public PackagesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CreatePackageInputModel inputModel)
        {
            Package package = new Package()
            {
                Title = inputModel.Title,
                Details = inputModel.Details,
                DeliveryDays = inputModel.DeliveryDays,
                PackageType = (TypeOfPackage)Enum.Parse(typeof(TypeOfPackage), inputModel.PackageType, true),
                ServiceId = inputModel.ServiceId,
                Price = inputModel.Price,
            };

            await this.dbContext.AddAsync(package);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
