using AutoMapper;
using ServiceProvider.Server.Data;
using ServiceProvider.Server.Models;
using ServiceProvider.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class ApplicationUsersService : IApplicationUsersService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ApplicationUsersService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public int CalculateRating(string userId)
        {
            // calculate rating:

            // sum all reviews rate from service that belongs to user
            // devide by the quantity of reviews


            //get service Ids for user and use it get reviews for certain service

            ICollection<int> belongedServiceIds = this.dbContext.Services.Where(s => s.UserId == userId).Select(s => s.Id).ToList();

            int sum = 0;
            int reviewsCount = 0;
            foreach (var serviceId in belongedServiceIds)
            {
                ICollection<int> reviewsRate = this.dbContext.Reviews.Where(r => r.ServiceId == serviceId).Select(r => r.Rate).ToList();
                sum += reviewsRate.Sum(r => r);
                reviewsCount += reviewsRate.Count;
            }

            if(sum == 0 || reviewsCount == 0)
            {
                return 0;
            }

            return (int)Math.Ceiling((double)(sum / reviewsCount));
        }

        public T GetById<T>(string userId)
        {
            return this.mapper.Map<T>(this.dbContext.Users.FirstOrDefault(x => x.Id == userId));
        }

        public async Task UpdateAsync(EditUserInputModel inputModel)
        {
            ApplicationUser applicationUser = this.dbContext.Users.FirstOrDefault(u => u.Id == inputModel.Id);
            applicationUser.FirstName = inputModel.FirstName;
            applicationUser.LastName = inputModel.LastName;
            applicationUser.Email = inputModel.Email;

            if(string.IsNullOrEmpty(inputModel.NewProfileImageUrl))
            {
                applicationUser.ProfilePictureUrl = inputModel.NewProfileImageUrl;
            }

            this.dbContext.Users.Update(applicationUser);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
