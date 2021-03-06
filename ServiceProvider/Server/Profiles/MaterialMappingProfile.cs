namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Materials;

    public class MaterialMappingProfile : Profile
    {
        public MaterialMappingProfile()
        {
            this.CreateMap<PackageMaterial, MaterialViewModel>()
                .ForMember(des => des.Name, y => y.MapFrom(src => src.Material.Name))
                .ForMember(des => des.Id, y => y.MapFrom(src => src.MaterialId));
        }
    }
}
