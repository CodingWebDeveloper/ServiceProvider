using ServiceProvider.Server.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class UserSkill
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public TypeOfExperience ExperienceType { get; set; }
    }
}
