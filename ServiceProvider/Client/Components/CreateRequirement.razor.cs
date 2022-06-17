using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class CreateRequirement : ComponentBase
    {
        [Parameter]
        public EventCallback LoadRequirements { get; set; }

        [Parameter]
        public int ServiceId { get; set; }

        [Inject]
        public IRequirementsService RequirementsService { get; set; }

        private CreateRequirementInputModel inputModel = new CreateRequirementInputModel();

        private async Task Create()
        {
            this.inputModel.ServiceId = this.ServiceId;
            await this.RequirementsService.CreateAsync(this.inputModel);
            this.inputModel = new CreateRequirementInputModel();
        }

        private async Task OnValidSubmit()
        {
            await this.Create();
            await this.LoadRequirements.InvokeAsync();
        }

        //public void NavigateToPackages()
        //{
        //    this.NavigationManager.NavigateTo($"pricing/{this.ServiceId}");
        //}
    }
}
