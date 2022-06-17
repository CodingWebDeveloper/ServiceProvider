namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Services;

    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Service, ServiceViewModel>()
                .ForMember(s => s.Images, x => x.MapFrom(y => y.Images));
            this.CreateMap<Service, ServiceInfoViewModel>();
        }

    }
}
