using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class AllCategories : ComponentBase
    {
        [Inject]
        public ICategoriesService CategoriesService { get; set; }
        [Inject]
        public IJSRuntime JS { get; set; }

        private CreateCategoryInputModel model = new();
        private IEnumerable<CategoryViewModel> categories = new List<CategoryViewModel>();

        private async Task Create()
        {
            await this.CategoriesService.CreateAsync(this.model);
            await this.HidAddForm();
            await this.Load();
        }


        protected override async Task OnInitializedAsync()
        {
            await this.Load();
        }

        private async Task Load()
        {
            this.categories = await this.CategoriesService.GetAll<CategoryViewModel>();
        }

        async Task HidAddForm()
        {
            await this.JS.InvokeVoidAsync("hidAddForm");
        }
    }
}
