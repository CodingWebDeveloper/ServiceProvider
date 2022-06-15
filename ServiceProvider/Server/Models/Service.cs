namespace ServiceProvider.Server.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        public string Title { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool IsPublished { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
