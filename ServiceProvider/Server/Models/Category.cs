using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Category
    {
        public Category()
        {
            this.Services = new HashSet<Service>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
