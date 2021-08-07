using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Skills : ComponentBase
    {
        [Parameter]
        public IEnumerable<SkillViewModel> AllSkills { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        async Task ShowAddForm()
        {
            await this.JS.InvokeVoidAsync("showAddForm");
        }
    }
}
