using AutoMapper;
using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Server.Models.Enums;
using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public SkillsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddSkill(AddSkillInputModel inputModel)
        {
            Skill skill = new()
            {
                Name = inputModel.Name
            };

            UserSkill userSkill = new()
            {
                UserId = inputModel.UserId,
                Skill = skill,
                ExperienceType = (TypeOfExperience)Enum.Parse(typeof(TypeOfExperience), inputModel.ExperienceType, true),
            };

            await this.dbContext.UserSkills.AddAsync(userSkill);

            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllBy<T>(string userId)
        {
            return this.mapper.ProjectTo<T>(this.dbContext.UserSkills.Where(us => us.UserId == userId));
        }
    }
}
