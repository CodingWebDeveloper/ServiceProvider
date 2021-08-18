using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Gallery : ComponentBase
    {

        [Parameter]
        public int ServiceId { get; set; }
    }
}
