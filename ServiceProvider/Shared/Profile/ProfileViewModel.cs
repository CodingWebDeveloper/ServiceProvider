using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Profile
{
    public class ProfileViewModel
    {
        public IEnumerable<ServiceViewModel> Services { get; set; }
    }
}
