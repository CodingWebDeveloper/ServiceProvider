using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Service
    {
        public Service()
        {
            this.Packages = new HashSet<Package>();
            this.Reviews = new HashSet<Review>();
            this.Images = new HashSet<Image>();
            this.Requirements = new HashSet<Requirement>();
        }

        [Key]
        public int Id { get; set; }

        public double Rating { get; set; } = 0;

        public string Title { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
