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

        decimal GetStartingPrice(int serviceId);

        int GetUnfinishedOrdersBy(int serviceId);

        Task PublishServiceBy(int serviceId);

        T GetById<T>(int serviceId);

        IEnumerable<T> GetAll<T>();

        int GetRatingById(int serviceId);
    }
}
