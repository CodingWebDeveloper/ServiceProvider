using ServiceProvider.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public interface IApplicationUsersService
    {
        Task<T> GetById<T>();

        Task UpdateAsync(EditUserInputModel inputModel);
    }
}
