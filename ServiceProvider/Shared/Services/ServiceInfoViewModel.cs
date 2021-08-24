namespace ServiceProvider.Shared.Services
{
    using AutoMapper;
    using ServiceProvider.Shared.Images;
    using ServiceProvider.Shared.PackageModels;
    using ServiceProvider.Shared.Reviews;
    using ServiceProvider.Shared.Users;
    using System.Collections.Generic;

    public class ServiceInfoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public UserViewModel User { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        [IgnoreMap]
        public int CurrentPendingOrdersCount { get; set; }

        [IgnoreMap]
        public int CompletedOrdersCount { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        public IEnumerable<PackageViewModel> Packages { get; set; }
    }
}
