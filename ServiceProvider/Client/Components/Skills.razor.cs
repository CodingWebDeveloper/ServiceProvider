using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Skills : ComponentBase
    {
        private IEnumerable<SkillViewModel> skills;

        [Inject]
        public ISkillsService SkillsService { get; set; }

        private string searchString = "";

        private bool openCreateForm;

        private string buttonToggleText = "Create Skill";

        private int nr = 1;

        private void ToggleCreateSkillForm()
        {
            if (this.openCreateForm)
            {
                this.buttonToggleText = "Create Skill";
            }
            else
            {
                this.buttonToggleText = "Cancel";
            }

            this.openCreateForm = !this.openCreateForm;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadSkills();
            await base.OnInitializedAsync();
        }

        private async Task LoadSkills()
        {
            this.skills = await this.SkillsService.GetAllByUser<SkillViewModel>();
        }
    }
}
