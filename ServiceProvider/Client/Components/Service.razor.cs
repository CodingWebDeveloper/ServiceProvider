using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Service : ComponentBase
    {
        [Parameter]
        public int ServiceId { get; set; }

        [Inject]
        public IServicesService ServicesService { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        private ServiceInfoViewModel service= new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                this.service = await this.ServicesService.GetById<ServiceInfoViewModel>(this.ServiceId);
                this.StateHasChanged();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
            }
            await base.OnInitializedAsync();
            await this.JS.InvokeVoidAsync("showSlides", 1);
        }
    }
}
