using ServiceProvider.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface IApplicationUsersService
    {
        T GetById<T>(string userId);

        Task UpdateAsync(EditUserInputModel inputModel);

        int CalculateRating(string userId);
    }
}
