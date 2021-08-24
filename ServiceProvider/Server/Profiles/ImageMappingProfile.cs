namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Images;

    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            this.CreateMap<Image, ImageViewModel>();
        }
    }
}
