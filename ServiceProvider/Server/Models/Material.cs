using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Material
    {
        public Material()
        {
            this.Packages = new HashSet<PackageMaterial>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PackageMaterial> Packages { get; set; }
    }
}
