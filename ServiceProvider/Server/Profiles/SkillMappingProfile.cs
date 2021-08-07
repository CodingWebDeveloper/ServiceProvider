using AutoMapper;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Profiles
{
    public class SkillMappingProfile : Profile
    {
        public SkillMappingProfile()
        {
            this.CreateMap<UserSkill, SkillViewModel>()
                .ForMember(v => v.Name, y => y.MapFrom(us => us.Skill.Name))
                .ForMember(v => v.ExperienceType, y => y.MapFrom(us => us.ExperienceType.ToString()));
        }
    }
}
