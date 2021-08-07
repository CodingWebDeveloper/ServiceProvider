using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Services
{
    public interface ISkillsService
    {
        Task AddSkill(AddSkillInputModel inputModel);

        Task<IEnumerable<T>> GetAllByUser<T>();
    }
}
