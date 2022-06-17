using Microsoft.AspNetCore.Components;
using MudBlazor;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class CreatedServicesByUser : ComponentBase
    {
        [Inject]
        public IServicesService ServicesService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private IEnumerable<ServiceViewModel> services;

        private Transition transition = Transition.Slide;



        protected override async Task OnInitializedAsync()
        {
            await this.LoadServices();
            await base.OnInitializedAsync();
        }

        private async Task LoadServices()
        {
            this.services = await this.ServicesService.GetAllByUserId<ServiceViewModel>();
            //foreach (var service in this.services)
            //{
            //    service.StartingPrice = await this.ServicesService.GetStartingPrice(service.Id);
            //    service.Rating = await this.ServicesService.Cal
            //}

            this.StateHasChanged();
        }

        private void GotToServiceDetails(int serviceId)
        {
            this.NavigationManager.NavigateTo($"services/service-details/{serviceId}");
        }
    }
}
