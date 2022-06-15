using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using ServiceProvider.Client.Services;
using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ServiceProvider.Client.Components
{
    public partial class Gallery : ComponentBase
    {
        [Parameter]
        public int ServiceId { get; set; }

        [Parameter]
        public EventCallback IncreaseProccessStep { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IImagesService ImagesService { get; set; }

        private EditContext editContext;
        private UploadImagesInputModel inputModel;

        private ICollection<IFormFile> Images;

        protected override void OnInitialized()
        {
            this.inputModel = new();
            this.editContext = new EditContext(this.inputModel);
            this.Images = new List<IFormFile>();

            base.OnInitialized();
        }

        private async Task OnChangeInputFile(InputFileChangeEventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            await e.File.OpenReadStream(2000000).CopyToAsync(ms);
            IFormFile file = new FormFile(ms, 0, ms.Length, "name", e.File.Name);
            this.Images.Add(file);
        }
        
        private async Task Save()
        {
            IDictionary<string, byte[]> ByteArrayData = new Dictionary<string, byte[]>();
            IDictionary<string, int> repeatingFileNames = new Dictionary<string, int>();
            foreach (var image in this.Images)
            {
                byte[] destinationData;

                using (var ms = new MemoryStream())
                {
                    await image.CopyToAsync(ms);
                    destinationData = ms.ToArray();
                }

                if (ByteArrayData.ContainsKey(image.FileName))
                {
                    if (repeatingFileNames.ContainsKey(image.FileName))
                    {
                        ByteArrayData.Add($"{image.FileName} ({repeatingFileNames[image.FileName]++})", destinationData);
                    }
                }
                else
                {
                    ByteArrayData.Add(image.FileName, destinationData);
                    repeatingFileNames.Add(image.FileName, 1);
                }
            }
            
            this.inputModel.ByteArrayData = ByteArrayData;
            this.inputModel.ServiceId = this.ServiceId;
            await this.ImagesService.CreateAsync(this.inputModel);
            this.NavigationManager.NavigateTo($"publish/{this.ServiceId}");
        }
    }
}
