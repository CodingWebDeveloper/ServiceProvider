namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.PackageModels;

    public class PackageMappingProfile : Profile
    {
        public PackageMappingProfile()
        {
            this.CreateMap<Package, PackageViewModel>();
        }
    }
}
