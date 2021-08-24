using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Images
{
    public class CreateImageInputModel
    {
        public string RemoteUrl { get; set; }

        public int ServiceId { get; set; }
    }
}
