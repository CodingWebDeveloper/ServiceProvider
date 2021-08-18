using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Server.Models.Enums;
using ServiceProvider.Shared.PackageModels;
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
            Package package = new()
            {
                Title = inputModel.Title,
                Details = inputModel.Details,
                DeliveryDays = inputModel.DeliveryDays,
                PackageType = (TypeOfPackage)Enum.Parse(typeof(TypeOfPackage), inputModel.PackageType, true),
                ServiceId = inputModel.ServiceId,
                Price = inputModel.Price,
            };

            foreach (var material in inputModel.Materials)
            {
                PackageMaterial newMaterial = new PackageMaterial()
                {
                    Material = new Material() 
                    {
                        Name = material.Name
                    },
                };
                if (this.dbContext.PackageMaterials.Any(pm => pm.Material.Name == material.Name))
                {
                    PackageMaterial existingMaterial = this.dbContext.PackageMaterials.FirstOrDefault(pm => pm.Material.Name == material.Name);
                    package.Materials.Add(existingMaterial);
                }
                else
                {
                    package.Materials.Add(newMaterial);
                }
            }

            await this.dbContext.Packages.AddAsync(package);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
