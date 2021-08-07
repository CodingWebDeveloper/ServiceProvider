using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Categories;
using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class CreateService : ComponentBase
    {
        [Inject]
        public IServicesService ServicesService { get; set; }

        [Inject]
        public ICategoriesService CategoriesService { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private int descriptionLength;

        private readonly CreateServiceInputModel model = new();

        private int serviceId;
       
        protected override async Task OnInitializedAsync()
        {
            this.model.Title = "I will";
            this.model.ListItems = new List<CategoryViewModel>();
            this.model.ListItems = await this.CategoriesService.GetAll<CategoryViewModel>();
        }

        private async Task Create()
        {
            this.serviceId = await this.ServicesService.CreateAsync(this.model);
            string uri = $"requirements/{this.serviceId}";
            this.NavigationManager.NavigateTo(uri);
        }

        private void OnCategoryChanged(ChangeEventArgs e)
        {
            this.model.CategoryId = int.Parse(e.Value.ToString());
        }

        private void OnValueChanged(ChangeEventArgs e)
        {
            this.descriptionLength = e.Value.ToString().Length;
            this.StateHasChanged();
        }
    }
}
