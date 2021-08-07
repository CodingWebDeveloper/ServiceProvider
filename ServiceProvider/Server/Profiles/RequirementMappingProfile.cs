using AutoMapper;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Profiles
{
    public class RequirementMappingProfile : Profile
    {
        public RequirementMappingProfile()
        {
            this.CreateMap<Requirement, RequirementViewModel>();
            this.CreateMap<Requirement, EditRequirementInputModel>();
        }
    }
}
