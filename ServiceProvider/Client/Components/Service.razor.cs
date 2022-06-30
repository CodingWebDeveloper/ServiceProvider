using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.PackageModels;
using ServiceProvider.Shared.Services;
using ServiceProvider.Shared.Users;
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
        public IPackagesService PackagesService { get; set; }

        [Inject]
        public IApplicationUsersService ApplicationUsersService { get; set; }

        private ServiceDetails service= new ServiceDetails();

        protected override async Task OnInitializedAsync()
        {
            this.service = await this.ServicesService.GetById<ServiceDetails>(this.ServiceId);
            this.service.Packages = await this.PackagesService.GetAllBy<PackageViewModel>(this.ServiceId);
            this.service.Creator = await this.ApplicationUsersService.GetById<UserViewModel>();
            this.service.CurrentPendingOrdersCount = await this.ServicesService.GetUnfinishedOrdersBy(this.ServiceId);

            await base.OnInitializedAsync();
            this.StateHasChanged();
        }
    }
}
