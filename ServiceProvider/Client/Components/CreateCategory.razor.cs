using Microsoft.AspNetCore.Components;
using MudBlazor;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Categories;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class CreateCategory : ComponentBase
    {
        [Inject]
        public ICategoriesService CategoriesService { get; set; }

        [Parameter]
        public EventCallback LoadSkills { get; set; }

        private CreateCategoryInputModel inputModel = new CreateCategoryInputModel();

        private MudTextField<string> pwField;

        private bool success;

        private MudForm form;

        private async Task Create()
        {
            await this.CategoriesService.CreateAsync(this.inputModel);
            this.inputModel = new CreateCategoryInputModel();
            await this.LoadSkills.InvokeAsync();
        }
    }
}
