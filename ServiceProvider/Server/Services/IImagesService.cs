﻿using ServiceProvider.Shared.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Services
{
    public interface IImagesService
    {
        Task CreateAsync(CreateImageInputModel inputModel);

        //IEnumerable<T> GetAllBy<T>(int serviceId);
    }
}
