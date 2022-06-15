using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Profile;
using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{ 
    public partial class Profile : ComponentBase
    {
        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        

        
    }
}
