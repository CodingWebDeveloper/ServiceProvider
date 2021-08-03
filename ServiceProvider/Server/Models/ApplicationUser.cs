using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Occupations = new HashSet<UserOccupation>();
            this.Skills = new HashSet<UserSkill>();
            this.Services = new HashSet<Service>();
            this.PlacedOrders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();
        }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Rating { get; set; } = 0;

        public string ProfilePictureUrl { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public ICollection<UserOccupation> Occupations { get; set; }

        public virtual ICollection<UserSkill> Skills { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<Order> PlacedOrders { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
