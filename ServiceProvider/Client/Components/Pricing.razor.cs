using Microsoft.AspNetCore.Components;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Materials;
using ServiceProvider.Shared.Packages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Client.Components
{
    public partial class Pricing : ComponentBase
    {

        [Parameter]
        public int ServiceId { get; set; }

        [Inject]
        public IPackagesService PackagesService { get; set; }

        private int packagesWanted = 3;

        private int count;

        private Dictionary<int, CreatePackageInputModel> packages = new Dictionary<int, CreatePackageInputModel>();
        private Dictionary<int, CreateMaterialInputModel> materials = new Dictionary<int, CreateMaterialInputModel>();
       
        private CreatePackageInputModel BasicPackageInputModel = new CreatePackageInputModel();

        private CreatePackageInputModel StandardPackageInputModel = new CreatePackageInputModel();

        private CreatePackageInputModel PremiumPackageInputModel = new CreatePackageInputModel();

        protected override void OnInitialized()
        {
            for (int i = 1; i <= 3; i++)
            {
                CreatePackageInputModel inputModel = new CreatePackageInputModel();
                this.packages[i] = inputModel;
                inputModel.Materials = new List<CreateMaterialInputModel>();
            }

            //this.BasicPackageInputModel.Number = 1;
            //this.StandardPackageInputModel.Number = 2;
            //this.PremiumPackageInputModel.Number = 3;
        }

        public void AddMaterial()
        {
            CreateMaterialInputModel inputModel = new CreateMaterialInputModel();
            this.count++;

            inputModel.Name = $"{this.count}";
            this.materials[count] = inputModel;
            this.StateHasChanged();
        }

        private void CheckMaterialToPackage(int packageNumber, int materialNumber)
        {
            foreach (var package in this.packages)
            {
                if (package.Value.Materials.Any(m => m == this.materials[materialNumber]))
                {
                    this.packages[package.Key].Materials.Remove(this.materials[materialNumber]);
                    break;
                }
            }


            this.packages[packageNumber].Materials.Add(this.materials[materialNumber]);
            this.StateHasChanged();
        }

        public async Task Save()
        {
            foreach (var package in packages)
            {
                await this.PackagesService.CreateAsync(package.Value);
                await Task.Delay(5000);
            }
        }

    }
}
