using ServiceProvider.Shared.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.PackageModels
{
    public class PackageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int DeliveryDays { get; set; }

        public string Details { get; set; }

        public double Price { get; set; }

        public int ServiceId { get; set; }

        public string PackageType { get; set; }

        public IEnumerable<MaterialViewModel> Materials { get; set; }
    }
}
