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

    public class ServiceDetails
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [IgnoreMap]
        public decimal Rating { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        [IgnoreMap]
        public UserViewModel Creator { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        [IgnoreMap]
        public int CurrentPendingOrdersCount { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        //public IEnumerable<PackageViewModel> Packages { get; set; }

        //public IEnumerable<RequirementViewModel> Requirements { get; set; }
    }
}
