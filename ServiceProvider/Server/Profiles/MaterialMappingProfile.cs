using AutoMapper;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Profiles
{
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
