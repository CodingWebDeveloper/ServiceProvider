namespace ServiceProvider.Server.Profiles
{
    using AutoMapper;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Categories;

    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            this.CreateMap<Category, CategoryViewModel>();
        }
    }
}
