namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Requirements;

    public class RequirementMappingProfile : Profile
    {
        public RequirementMappingProfile()
        {
            this.CreateMap<Requirement, RequirementViewModel>();
            this.CreateMap<Requirement, EditRequirementInputModel>();
        }
    }
}
