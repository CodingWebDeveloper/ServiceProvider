using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface ICloudinaryService
    {
        public Task<string> UploadPicture(byte[] destiantionData, string fileName);
    }
}
