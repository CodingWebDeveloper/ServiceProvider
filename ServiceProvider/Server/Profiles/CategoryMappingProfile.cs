using AutoMapper;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            this.CreateMap<Category, CategoryViewModel>();
        }
    }
}
