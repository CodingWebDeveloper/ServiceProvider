using Microsoft.AspNetCore.Components;
using MudBlazor;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Skills;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class CreateSkill : ComponentBase
    {
        [Inject]
        public ISkillsService SkillsService { get; set; }

        [Parameter]
        public EventCallback LoadSkills { get; set; }

        //private EditContext context;

        private AddSkillInputModel inputModel = new AddSkillInputModel();

        MudTextField<string> pwField;

        private bool success;

        MudForm form;

        private readonly IEnumerable<string> experienceTypes = new List<string>() { "Beginner", "Intermediate", "Expert" };

        //private string Disabled { get; set; } = "disabled";

        private async Task Create()
        {
            await this.SkillsService.Create(this.inputModel);
            this.inputModel = new AddSkillInputModel();
            await this.LoadSkills.InvokeAsync();
        }
    }
}
