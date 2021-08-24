using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinaryUtility;

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public async Task<string> UploadPicture(byte[] destinationData, string fileName)
        {
            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams() 
                {
                    Folder = "gallery",
                    File = new FileDescription(fileName,ms),
                };

                uploadResult = await this.cloudinaryUtility.UploadAsync(uploadParams);
            }

            return uploadResult?.SecureUrl.AbsoluteUri;
        }
    }
}
