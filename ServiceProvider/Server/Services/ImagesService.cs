namespace ServiceProvider.Server.Services
{
    using AutoMapper;
    using ServiceProvider.Server.Data;
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

        public Task CreateAsync(CreateImagesInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllBy<T>(int serviceId)
        {
            return this.mapper.ProjectTo<T>(this.dbContext.Images.Where(img => img.ServiceId == serviceId));
        }
    }
}
