using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
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
        private int currentProccessStep = 1;
        private int serviceId;

        //private async Task Create()
        //{
        //    this.serviceId = await this.ServicesService.CreateAsync(this.model);
        //    string uri = $"requirements/{this.serviceId}";
        //    this.NavigationManager.NavigateTo(uri);
        //}

        //private void OnCategoryChanged(ChangeEventArgs e)
        //{
        //    this.model.CategoryId = int.Parse(e.Value.ToString());
        //}

        //private void OnValueChanged(ChangeEventArgs e)
        //{
        //    this.descriptionLength = e.Value.ToString().Length;
        //    this.StateHasChanged();
        //}

        private void IncreaseProccessStep()
        {
            this.currentProccessStep++;
        }

        private void GetServiceId(int serviceId)
        {
            this.serviceId = serviceId;
        }
    }
}
