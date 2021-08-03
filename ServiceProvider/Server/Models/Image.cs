using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string RemoteUrl { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
