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

        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [IgnoreMap]
        public double Rating { get; set; }

        public string ProfilePictureUrl { get; set; }

        public int CountOfReviews { get; set; } = 0;

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

    }
}
