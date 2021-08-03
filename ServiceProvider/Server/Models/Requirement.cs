using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Requirement
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
