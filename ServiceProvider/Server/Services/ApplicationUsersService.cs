using AutoMapper;
using ServiceProvider.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class ApplicationUsersService : IApplicationUser
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ApplicationUsersService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public T GetBy<T>(string userId)
        {
            return this.mapper.Map<T>(this.dbContext.Users.FirstOrDefault(x => x.Id == userId));
        }
    }
}
