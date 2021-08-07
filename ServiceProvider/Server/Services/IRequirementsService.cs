using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface IRequirementsService
    {
        Task CreateAsync(CreateRequirementInputModel inputModel);


        Task UpdateAsync(EditRequirementInputModel inputModel);

        Task DeleteAsync(int requirementId);

        Task<T> GetAsync<T>(int requirementId);

        IEnumerable<T> GetAllBy<T>(int serviceId);
    }
}
