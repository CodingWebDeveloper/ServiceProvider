using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Profile;
using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Profile : ComponentBase
    {
        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IServicesService ServicesService { get; set; }

        private IEnumerable<ServiceViewModel> services = new List<ServiceViewModel>();


        protected override async Task OnInitializedAsync()
        {
            await this.LoadServices();
            await base.OnInitializedAsync();
            await this.JS.InvokeVoidAsync("showSlides", 1);

        }

        public async Task LoadServices()
        {
            this.services = await this.ServicesService.GetAllByUserId<ServiceViewModel>();
            foreach (var service in this.services)
            {
                service.StartingPrice = await this.ServicesService.GetStartingPrice(service.Id);
            }

            this.StateHasChanged();
        }

        public void ViewServiceInfo(int serviceId)
        {
            this.NavigationManager.NavigateTo($"service-info/{serviceId}");
        }
    }
}
