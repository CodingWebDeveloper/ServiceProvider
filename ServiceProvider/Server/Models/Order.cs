using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Order
    {
        public Order()
        {
            this.Files = new HashSet<File>();
        }

        [Key]
        public int Id { get; set; }

        public string Details { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<File> Files { get; set; }

        public double Rate { get; set; } = 0;

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }

        public DateTime? FinishedDate { get; set; }
    }
}
