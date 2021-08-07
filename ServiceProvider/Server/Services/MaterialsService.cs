using AutoMapper;
using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class MaterialsService : IMaterialsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public MaterialsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateMaterialInputModel inputModel)
        {
            Material material = new Material()
            {
                Name = inputModel.Name,
            };

            await this.dbContext.Materials.AddAsync(material);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBy<T>(int pakageId)
        {
            return this.mapper.ProjectTo<T>(this.dbContext.PackageMaterials.Where(pm => pm.PackageId == pakageId));
        }
    }
}
