using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Categories : ComponentBase
    {
        [Inject]
        public ICategoriesService CategoriesService { get; set; }

        private CreateCategoryInputModel model = new CreateCategoryInputModel();

        private int nr = 1;

        private bool openCreateForm;

        private string searchString = "";


        private IEnumerable<CategoryViewModel> categories = new List<CategoryViewModel>();

        private async Task Create()
        {
            await this.CategoriesService.CreateAsync(this.model);
            await this.LoadCategories();
        }


        protected override async Task OnInitializedAsync()
        {
            await this.LoadCategories();
        }

        private async Task LoadCategories()
        {
            this.categories = await this.CategoriesService.GetAll<CategoryViewModel>();
        }

        public void OpenCreateForm() => this.openCreateForm = !this.openCreateForm;
       
    }
}
