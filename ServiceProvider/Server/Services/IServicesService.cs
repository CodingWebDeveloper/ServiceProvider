using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface IServicesService
    {
        Task<int> CreateAsync(CreateServiceInputModel inputModel);

        IEnumerable<T> GetAllBy<T>(string userId);

        double GetStartingPrice(int serviceId);

        T GetById<T>(int serviceId);
    }
}
