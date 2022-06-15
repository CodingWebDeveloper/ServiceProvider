using AutoMapper;
using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class RequirementsService : IRequirementsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public RequirementsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateRequirementInputModel inputModel)
        {
            Requirement requirement = new Requirement()
            {
                Content = inputModel.Content,
                ServiceId = inputModel.ServiceId,
            };

            await this.dbContext.Requirements.AddAsync(requirement);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int requirementId)
        {
            Requirement requirement = await this.dbContext.Requirements.FindAsync( new object[] {requirementId });
            this.dbContext.Requirements.Remove(requirement);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBy<T>(int serviceId)
        {
            return this.mapper.ProjectTo<T>(this.dbContext.Requirements.Where(r => r.ServiceId == serviceId));
        }

        public async Task<T> GetAsync<T>(int requirementId)
        {
            return this.mapper.Map<T>(await this.dbContext.Requirements.FindAsync(new object[] { requirementId }));
        }

        public async Task UpdateAsync(UpdateRequirementInputModel inputModel)
        {
            Requirement requirement = await this.dbContext.Requirements.FindAsync(new object[] { inputModel.Id });

            if (requirement == null)
            {
                return;
            }

            requirement.Content = inputModel.Content;
            this.dbContext.Requirements.Update(requirement);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
