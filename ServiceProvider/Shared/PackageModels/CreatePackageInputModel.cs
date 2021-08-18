using ServiceProvider.Shared.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.PackageModels
{
    public class CreatePackageInputModel
    {
        public int Number { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public int DeliveryDays { get; set; }

        public string PackageType { get; set; }

        public int ServiceId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public ICollection<CreateMaterialInputModel> Materials { get; set; }
    }
}
