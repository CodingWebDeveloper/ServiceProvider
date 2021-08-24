namespace ServiceProvider.Shared.Profile
{
    using ServiceProvider.Shared.Services;
    using System.Collections.Generic;

    public class ProfileViewModel
    {
        public IEnumerable<ServiceViewModel> Services { get; set; }
    }
}
