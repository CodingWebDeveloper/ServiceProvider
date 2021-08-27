using Microsoft.AspNetCore.Components;
using ServiceProvider.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlafettisLib;

namespace ServiceProvider.Client.Components
{
    public partial class PublishService : ComponentBase
    {
        [Parameter]
        public int ServiceId { get; set; }

        //[Inject]
        //public ServicesService ServicesService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected Blafettis blafettis;

        private string btnShow = "block";

       async Task Publish()
       {
            //await this.ServicesService.PublishServiceBy(this.ServiceId);
            this.blafettis.RaiseConfetti();
            this.btnShow = "none";
            await Task.Delay(3500);
            this.NavigationManager.NavigateTo($"congrats/{this.ServiceId}");
       }
    }
}
