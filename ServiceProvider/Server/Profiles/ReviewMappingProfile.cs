namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Reviews;

    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            this.CreateMap<Review, ReviewViewModel>()
                .ForMember(rvm => rvm.CreatorUserName, y => y.MapFrom(u => u.Creator.UserName))
                .ForMember(rvm => rvm.CreatorProfilePicture, y => y.MapFrom(u => u.Creator.ProfilePictureUrl));
        }
    }
}
