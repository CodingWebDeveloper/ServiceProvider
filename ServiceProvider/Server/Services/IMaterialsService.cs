using ServiceProvider.Shared.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface IMaterialsService
    {
        Task CreateAsync(CreateMaterialInputModel inputModel);

        IEnumerable<T> GetAllBy<T>(int pakageId);
    }
}
