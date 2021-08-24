namespace ServiceProvider.Server.Services
{
    using AutoMapper;
    using ServiceProvider.Server.Data;
    using ServiceProvider.Server.Models;
    using ServiceProvider.Shared.Images;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ImagesService : IImagesService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ImagesService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync(CreateImageInputModel inputModel)
        {
            Image image = new Image()
            {
                RemoteUrl = inputModel.RemoteUrl,
                ServiceId = inputModel.ServiceId,
            };

            await this.dbContext.Images.AddAsync(image);
            await this.dbContext.SaveChangesAsync();
        }

        //public IEnumerable<T> GetAllBy<T>(int serviceId)
        //{
        //    return this.mapper.ProjectTo<T>(this.dbContext.Images.Where(img => img.ServiceId == serviceId));
        //}
    }
}
