using ServiceProvider.Shared.PackageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface IPackagesService
    {
        Task CreateAsync(CreatePackageInputModel inputModel);
    }
}
