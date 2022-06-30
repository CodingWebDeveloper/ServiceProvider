using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public int Rate { get; set; } = 0;

        public string Content { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
