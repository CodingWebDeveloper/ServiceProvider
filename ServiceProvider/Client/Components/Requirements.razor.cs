using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Requirements;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Requirements : ComponentBase
    {

        [Parameter]
        public EventCallback IncreaseProccessStep { get; set; }

        [Parameter]
        public int ServiceId { get; set; }

        [Inject]
        public IRequirementsService RequirementsService { get; set; }

        private bool IsUpdating = false;

        private int requirementToModify;


        private IEnumerable<RequirementViewModel> requirements = new List<RequirementViewModel>();

        protected override async Task OnInitializedAsync()
        {
           await this.LoadRequirements();
           await base.OnInitializedAsync();
        }

        private async Task LoadRequirements()
        {
            this.requirements = await this.RequirementsService.GetAllBy<RequirementViewModel>(this.ServiceId);
            this.IsUpdating = false;
            this.StateHasChanged();
        }

        private void OpenModifyForm(int requirementId)
        {
            this.IsUpdating = true;
            this.requirementToModify = requirementId;
        }

        public void CancelUpdate()
        {
            this.IsUpdating = false;
        }

        public async Task Delete(int requirementId)
        {
            await this.RequirementsService.DeleteAsync(requirementId);
            await this.LoadRequirements();
        }
    }
}
