using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        public string RemoteUrl { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
