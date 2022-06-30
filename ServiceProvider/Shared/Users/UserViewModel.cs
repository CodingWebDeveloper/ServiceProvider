using AutoMapper;
using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
        
        public string FirstName { get; set; }

        public string NameInitials => this.FirstName.Substring(0, 1) + this.LastName.Substring(0, 1);
        
        public string LastName { get; set; }

        [IgnoreMap]
        public int Rating { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

        [IgnoreMap]
        public string Test { get; set; }

    }
}
