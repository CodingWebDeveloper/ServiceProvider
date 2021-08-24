using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Services;
using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly IImagesService imagesService;

        public ImagesController(ICloudinaryService cloudinaryService, IImagesService imagesService)
        {
            this.cloudinaryService = cloudinaryService;
            this.imagesService = imagesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(UploadImagesInputModel inputModel)
        {
            foreach (var image in inputModel.ByteArrayData)
            {
                string remoteUrl = await this.cloudinaryService.UploadPicture(image.Value,image.Key);
                CreateImageInputModel imageInputModel = new CreateImageInputModel()
                {
                    RemoteUrl = remoteUrl,
                    ServiceId = inputModel.ServiceId,
                };

                await this.imagesService.CreateAsync(imageInputModel);
            }

            return this.Ok();
        }
    }
}
