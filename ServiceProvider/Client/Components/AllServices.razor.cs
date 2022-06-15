using Microsoft.AspNetCore.Components;
using MudBlazor;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class AllServices : ComponentBase
    {
        private IEnumerable<ServiceViewModel> services;

        private Transition transition = Transition.Slide;

        [Inject]
        public IServicesService ServicesService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            this.services = await this.ServicesService.GetAll<ServiceViewModel>();

            await base.OnInitializedAsync();
        }
    }
}
