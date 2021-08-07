using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface ISkillsService
    {
        Task AddSkill(AddSkillInputModel inputModel);

        IEnumerable<T> GetAllBy<T>(string userId);
    }
}
