using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public interface IRequirementsService
    {

        Task CreateAsync(CreateRequirementInputModel inputModel);

        Task DeleteAsync(int requirementId);

        Task UpdateAsync(EditRequirementInputModel inputModel);

        Task<T> GetAsync<T>(int requirementId);

        Task<IEnumerable<T>> GetAllBy<T>(int serviceId);
    }
}
