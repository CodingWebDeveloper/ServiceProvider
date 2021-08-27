using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
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
        public IApplicationUsersService ApplicationUsersService { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        private ServiceInfoViewModel service= new();

        protected override async Task OnInitializedAsync()
        {
            this.service = await this.ServicesService.GetById<ServiceInfoViewModel>(this.ServiceId);
            this.service.Creator = await this.ApplicationUsersService.GetById<UserViewModel>();
            this.service.CurrentPendingOrdersCount = await this.ServicesService.GetUnfinishedOrdersBy(this.ServiceId);
            this.StateHasChanged();
            await base.OnInitializedAsync();
            if(this.service.Images.Any())
            {
                await this.JS.InvokeVoidAsync("showSlides", 1);
            }
           
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await this.JS.InvokeVoidAsync("openPackage", "Basic");
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
