using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Requirements;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class UpdateRequirement : ComponentBase
    {
        [Parameter]
        public EventCallback LoadRequirements { get; set; }

        [Parameter]
        public EventCallback CancelUpdate { get; set; }

        [Parameter]
        public int RequirementId { get; set; }

        [Inject]
        public IRequirementsService RequirementsService { get; set; }

        private UpdateRequirementInputModel inputModel = new UpdateRequirementInputModel();

        protected override async Task OnInitializedAsync()
        {
            this.inputModel = await this.RequirementsService.GetById<UpdateRequirementInputModel>(this.RequirementId);
            await base.OnInitializedAsync();
            this.StateHasChanged();
        }

        private async Task OnValidSubmit(EditContext context)
        {
            await this.Update();
            await this.LoadRequirements.InvokeAsync();
            await this.CancelUpdate.InvokeAsync();
        }

        private async Task Update()
        {
            await this.RequirementsService.UpdateAsync(this.inputModel);
            this.inputModel = new UpdateRequirementInputModel();
        }
    }
}
