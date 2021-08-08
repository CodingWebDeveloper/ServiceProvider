using AutoMapper;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Profiles
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            this.CreateMap<Image, ImageViewModel>();
        }
    }
}
