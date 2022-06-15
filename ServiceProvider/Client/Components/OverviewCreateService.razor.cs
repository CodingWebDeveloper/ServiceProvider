using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Categories;
using ServiceProvider.Shared.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class OverviewCreateService : ComponentBase
    {
        [Parameter]
        public EventCallback IncreaseProccessStep { get; set; }

        [Parameter]
        public EventCallback<int> GetServiceId { get; set; }

        [Inject]
        public IServicesService ServicesService { get; set; }

        [Inject]
        private ICategoriesService CategoriesService { get; set; }

        private CreateServiceInputModel inputModel = new CreateServiceInputModel();
        private bool success = false;
        private int serviceId;
        private IEnumerable<CategoryAsSelectListItem> categories = new List<CategoryAsSelectListItem>();

        protected override async Task OnInitializedAsync()
        {
            this.categories = await this.CategoriesService.GetAll<CategoryAsSelectListItem>();
            await base.OnInitializedAsync();
        }

        private IEnumerable<string> MaxCaharctersDescription(string ch)
        {
            if (string.IsNullOrEmpty(ch) && 150 < ch?.Length)
            {
                yield return "Max 150 charactes";
            }
        }

        private IEnumerable<string> MaxCharactersTitle(string ch)
        {
            if (string.IsNullOrEmpty(ch) && 20 < ch?.Length)
            {
                yield return "Max 20 charactes";
            }
        }

        private bool CategoryValidate(int categoryId)
        {
            if (categoryId == 0)
            {
                return false;
            }

            return true;
        }

        private async Task Create()
        {
             this.serviceId = await this.ServicesService.CreateAsync(this.inputModel);
        }

        private async Task OnValidSubmit (EditContext context)
        {
            if(this.inputModel.CategoryId == 0 )
            {
                return;
            }

            this.success = true;
            this.StateHasChanged();
            await this.Create();

            await this.GetServiceId.InvokeAsync(this.serviceId);
            await this.IncreaseProccessStep.InvokeAsync();
        }
    }
}
