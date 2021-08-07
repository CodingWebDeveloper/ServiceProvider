using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class PackageMaterial
    {
        [Key]
        public int Id { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        public int MaterialId { get; set; }

        public virtual Material Material { get; set; }
    }
}
