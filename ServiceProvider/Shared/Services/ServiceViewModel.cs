namespace ServiceProvider.Shared.Services
{
    using AutoMapper;
    using ServiceProvider.Shared.Images;
    using System.Collections.Generic;

    public class ServiceViewModel
    {
        public int Id { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public string Title { get; set; }

        [IgnoreMap]
        public int Rating { get; set; }

        [IgnoreMap]
        public decimal StartingPrice { get; set; }
    }
}
