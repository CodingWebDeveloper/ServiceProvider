using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Skills
{
    public class AddSkillInputModel
    {
        public string UserId { get; set; }

        [Required]
        [MinLength(12)]
        public string Name { get; set; } = null;

        [Required]
        public string ExperienceType { get; set; } = null;
    }
}
