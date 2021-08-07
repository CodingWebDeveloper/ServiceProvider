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
        [Inject]
        public IRequirementsService RequirementsService { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private CreateRequirementInputModel createModel = new();
        private EditRequirementInputModel editModel = new();

        private IEnumerable<RequirementViewModel> requirements = new List<RequirementViewModel>();
        private bool IsUpdating = false;
        private int currentRequirementIdModify;

        [Parameter]
        public int ServiceId { get; set; }

        private async Task Create()
        {
            this.createModel.ServiceId = this.ServiceId;
            await this.RequirementsService.CreateAsync(this.createModel);
            this.createModel = new();
            await this.Load();
        }


        public async Task Delete(int requirementId)
        {
            await this.RequirementsService.DeleteAsync(requirementId);
            await this.Load();
        }

        private async Task Update(int requirementId = 0)
        {
            if(this.IsUpdating)
            {
                this.editModel.Id = this.currentRequirementIdModify;
                await this.RequirementsService.UpdateAsync(this.editModel);
                await this.Load();
                this.editModel = new();
                this.IsUpdating = false;
            }

        }

        private void CancelEditing()
        {
            this.IsUpdating = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await this.Load();
        }

        private async Task Load()
        {
             this.requirements = await this.RequirementsService.GetAllBy<RequirementViewModel>(this.ServiceId); 
        }


        private async Task OpenModifyForm(int requirementId)
        {
            this.IsUpdating = true;
            this.currentRequirementIdModify = requirementId;
            await this.ScrolltToTop();
        }

        private async Task ScrolltToTop()
        {
            await this.JS.InvokeVoidAsync("scrollToTop");
        }

        public void NavigateToPackages()
        {
            this.NavigationManager.NavigateTo($"pricing/{this.ServiceId}");
        }

    }
}
