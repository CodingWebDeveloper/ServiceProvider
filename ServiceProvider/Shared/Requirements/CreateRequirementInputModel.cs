using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Requirements
{
    public class CreateRequirementInputModel
    {
        [Required]
        public string Content { get; set; }

        public int ServiceId { get; set; }
    }
}
