using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public interface IServicesService
    {
        Task<int> CreateAsync(CreateServiceInputModel inputModel);

        Task<IEnumerable<T>> GetAllByUserId<T>();

        Task<decimal> GetStartingPrice(int serviceId);

        Task<int> GetUnfinishedOrdersBy(int serviceId);

        Task PublishServiceBy(int serviceId);

        Task<T> GetById<T>(int serviceId);

        Task<IEnumerable<T>> GetAll<T>();

        Task<int> GetRatingById(int serviceId);
    }
}
