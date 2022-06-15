namespace ServiceProvider.Client.Components
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;
    using ServiceProvider.Client.Services;
    using ServiceProvider.Shared.Materials;
    using ServiceProvider.Shared.PackageModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class Pricing : ComponentBase
    {

        private EditContext EditContextBasicPackage;
        private EditContext EditContextStandardPackage;
        private EditContext EditContextPremiumPackage;

        [Parameter]
        public int ServiceId { get; set; }

        [Parameter]
        public EventCallback IncreaseProccessStep { get; set; }

        [Inject]
        public IPackagesService PackagesService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string Disabled { get; set; } = "disabled";

        private int count;

        private Dictionary<int, CreateMaterialInputModel> materials = new ();
       
        private CreatePackageInputModel BasicPackageInputModel = new();

        private CreatePackageInputModel StandardPackageInputModel = new();

        private CreatePackageInputModel PremiumPackageInputModel = new();

        protected override void OnInitialized()

        {
            this.BasicPackageInputModel.PackageType = "Basic";
            this.BasicPackageInputModel.ServiceId = this.ServiceId;
            this.BasicPackageInputModel.Materials = new List<CreateMaterialInputModel>();

            this.StandardPackageInputModel.PackageType = "Standard";
            this.StandardPackageInputModel.ServiceId = this.ServiceId;
            this.StandardPackageInputModel.Materials = new List<CreateMaterialInputModel>();

            this.PremiumPackageInputModel.PackageType = "Premium";
            this.PremiumPackageInputModel.ServiceId = this.ServiceId;
            this.PremiumPackageInputModel.Materials = new List<CreateMaterialInputModel>();

            this.EditContextBasicPackage = new EditContext(this.BasicPackageInputModel);
            this.EditContextStandardPackage = new EditContext(this.StandardPackageInputModel);
            this.EditContextPremiumPackage = new EditContext(this.PremiumPackageInputModel);

            this.EditContextBasicPackage.OnFieldChanged += this.EditContext_OnFieldChanged;
            this.EditContextPremiumPackage.OnFieldChanged += this.EditContext_OnFieldChanged;
            this.EditContextStandardPackage.OnFieldChanged += this.EditContext_OnFieldChanged;

            base.OnInitialized();
        }

        public void AddMaterial()
        {
            CreateMaterialInputModel inputModel = new();
            this.count++;

            this.materials[count] = inputModel;
            this.StateHasChanged();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            this.SetSaveDisabledStatus();
        }

        private void CheckMaterialToPackage(int packageNumber, int materialNumber)
        {
            switch (packageNumber)
            {
                case 1:
                    this.BasicPackageInputModel.Materials.Add(this.materials[materialNumber]);
                    break;

                case 2:
                    this.StandardPackageInputModel.Materials.Add(this.materials[materialNumber]);
                    break;
                case 3:
                    this.PremiumPackageInputModel.Materials.Add(this.materials[materialNumber]);
                    break;
                default:
                    System.Console.WriteLine("No package with that number found");
                    break;
            }

            this.StateHasChanged();
        }

        public async Task Save()
        {
            await Task.Delay(3000);

            await this.PackagesService.CreateAsync(this.BasicPackageInputModel);
            await this.PackagesService.CreateAsync(this.StandardPackageInputModel);
            await this.PackagesService.CreateAsync(this.PremiumPackageInputModel);

            string uri = $"gallery/{this.ServiceId}";
            this.NavigationManager.NavigateTo(uri);
        }


        private void EditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            this.SetSaveDisabledStatus();
        }

        private void SetSaveDisabledStatus()
        {
            if (this.EditContextStandardPackage.Validate() && this.EditContextBasicPackage.Validate() && this.EditContextPremiumPackage.Validate())
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
