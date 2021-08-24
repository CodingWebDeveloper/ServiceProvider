
namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Users;

    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            this.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(x => x.UserName, y => y.MapFrom(u => u.UserName));
        }
    }
}
