using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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


        private EditContext context;

        private AddSkillInputModel inputModel = new();

        private readonly ICollection<string> experienceTypes = new List<string>() { "Beginner", "Intermediate", "Expert" };
        private IEnumerable<SkillViewModel> skills = new List<SkillViewModel>();

        private string Disabled { get; set; } = "disabled";

        private async Task AddNewSkill()
        {
            await this.SkillsService.AddSkill(this.inputModel);
            await this.HidAddForm();
            this.inputModel = new ();
            await this.Load();
        }

        private void OnValueChanged(ChangeEventArgs e)
        {
            this.inputModel.ExperienceType = e.Value.ToString();
        }

        protected override async Task OnInitializedAsync()
        {
            this.context = new EditContext(this.inputModel);
            this.context.OnFieldChanged += this.EditContext_OnFieldChanged;
            await this.Load();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if(firstRender)
            {
                this.SetSaveDisabledStatus();
            }
        }
        async Task Load()
        {
            this.skills = await this.SkillsService.GetAllByUser<SkillViewModel>();
        }

        async Task HidAddForm()
        {
            await this.JS.InvokeVoidAsync("hidAddForm");
        }

        private void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            this.SetSaveDisabledStatus();
        }

        private void SetSaveDisabledStatus()
        {
            if (this.context.Validate())
            {
                this.Disabled = null;
            }
            else
            {
                this.Disabled = "disabled";
            }
        }
    }
}
