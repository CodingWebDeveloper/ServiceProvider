using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Congrats : ComponentBase
    {
        [Parameter]
        public int ServiceId { get; set; }

        [Inject]
        public IWebAssemblyHostEnvironment HostEnvironment { get; set; }

        protected string linkService;

        protected override void OnInitialized()
        {
            this.linkService = $"{this.HostEnvironment.BaseAddress}/service-info/{this.ServiceId}";
            base.OnInitialized();
        }
    }
}
