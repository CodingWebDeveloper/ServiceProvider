using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Images
{
    public class UploadImagesInputModel
    {
        public IDictionary<string , byte[]> ByteArrayData { get; set; }

        public int ServiceId { get; set; }
    }
}
