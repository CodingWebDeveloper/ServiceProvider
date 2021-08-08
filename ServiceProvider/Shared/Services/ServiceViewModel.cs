using AutoMapper;
using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Services
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        [IgnoreMap]
        public int StartingPrice { get; set; }
    }
}
