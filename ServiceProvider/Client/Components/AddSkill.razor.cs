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
    public partial class AddSkill : ComponentBase
    {
        [Inject]
        public ISkillsService SkillsService { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }


        private readonly AddSkillInputModel inputModel = new();

        private readonly ICollection<string> experienceTypes = new List<string>() { "Beginner", "Intermediate", "Expert" };
        private IEnumerable<SkillViewModel> skills = new List<SkillViewModel>();

        private async Task AddNewSkill()
        {
            await this.SkillsService.AddSkill(this.inputModel);
            await this.HidAddForm();
            await this.Load();
        }

        private void OnValueChanged(ChangeEventArgs e)
        {
            this.inputModel.ExperienceType = e.Value.ToString();
        }

        protected override async Task OnInitializedAsync()
        {
            await this.Load();
        }


        async Task Load()
        {
            this.skills = await this.SkillsService.GetAllByUser<SkillViewModel>();
        }

        async Task HidAddForm()
        {
            await this.JS.InvokeVoidAsync("hidAddForm");
        }
    }
}
