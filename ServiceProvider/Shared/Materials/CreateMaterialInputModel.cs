using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Materials
{
    public class CreateMaterialInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
