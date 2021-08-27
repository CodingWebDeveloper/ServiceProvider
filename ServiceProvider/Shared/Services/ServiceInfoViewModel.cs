namespace ServiceProvider.Shared.Services
{
    using AutoMapper;
    using ServiceProvider.Shared.Images;
    using ServiceProvider.Shared.PackageModels;
    using ServiceProvider.Shared.Requirements;
    using ServiceProvider.Shared.Reviews;
    using ServiceProvider.Shared.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServiceInfoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [IgnoreMap]
        public double Rating => this.GetAvearageRatingByReveiws();

        public string Description { get; set; }

        public int CategoryId { get; set; }

        [IgnoreMap]
        public UserViewModel Creator { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        [IgnoreMap]
        public int CurrentPendingOrdersCount { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        public int ReviewsCount => this.GetReviewsCount();

        public IEnumerable<PackageViewModel> Packages { get; set; }

        public IEnumerable<RequirementViewModel> Requirements { get; set; }

        private  int GetReviewsCount()
        {
            if (!(this.Reviews is null))
            {
                return this.Reviews.Count();
            }

            return 0;
        }

        private double GetAvearageRatingByReveiws() 
        {
            if(!(this.Reviews is null))
            {
                if(this.Reviews.Any())
                {
                    return Math.Ceiling((double)this.Reviews.Sum(r => r.Rate) / (double)this.ReviewsCount);
                }
            }

            return 0;
        }

    }
}
