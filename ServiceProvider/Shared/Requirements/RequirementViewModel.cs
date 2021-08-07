using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Requirements
{
    public class RequirementViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ServiceId { get; set; }
    }
}
