using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Users;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class ProfileComponent : ComponentBase
    {
        [Inject]
        public IApplicationUsersService ApplicationUsersService { get; set; }

        private UserViewModel viewModel = new UserViewModel();

        [Inject]
        private IJSRuntime JsInterop { get; set; }

        private bool decriptionToggled;

        protected override async Task OnInitializedAsync()
        {
            this.viewModel = await this.ApplicationUsersService.GetById<UserViewModel>();
        }

        private async Task ToggleDescription()
        {
            this.decriptionToggled = !this.decriptionToggled;
            await this.JsInterop.InvokeVoidAsync("toggleDescription");
        }
    }
}
