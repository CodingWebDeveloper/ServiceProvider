using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Occupation
    {
        public Occupation()
        {
            this.Users = new HashSet<UserOccupation>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserOccupation> Users { get; set; }
    }
}
