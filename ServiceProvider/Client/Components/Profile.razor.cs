using Microsoft.AspNetCore.Components;
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
        public IServicesService ServicesService { get; set; }

        private IEnumerable<ServiceViewModel> services = new List<ServiceViewModel>();


        protected override async Task OnInitializedAsync()
        {
            await this.LoadServices();
        }

        public async Task LoadServices()
        {
            this.services = await this.ServicesService.GetAllByUserId<ServiceViewModel>();
        }
    }
}
