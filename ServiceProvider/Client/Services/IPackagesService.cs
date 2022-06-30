using ServiceProvider.Shared.PackageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public interface IPackagesService
    {
        Task CreateAsync(CreatePackageInputModel inputModel);

        Task<IEnumerable<T>> GetAllBy<T>(int serviceId);
    }
}
