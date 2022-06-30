
namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Users;
    using System.Linq;

    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            this.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(x => x.UserName, y => y.MapFrom(u => u.UserName));

            this.CreateMap<ApplicationUser, EditUserInputModel>();
        }
    }
}
