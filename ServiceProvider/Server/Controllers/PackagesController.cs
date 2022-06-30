using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Services;
using ServiceProvider.Shared.PackageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController: ControllerBase
    {
        private readonly IPackagesService packagesService;

        public PackagesController(IPackagesService packagesService)
        {
            this.packagesService = packagesService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePackage(CreatePackageInputModel inputModel)
        {
            await this.packagesService.CreateAsync(inputModel);

            return this.Ok();
        }

        [HttpGet("by-service-id/{serviceId}")]
        public IActionResult GetAllBy([FromRoute]int serviceId)
        {
            return this.Ok(this.packagesService.GetAllBy<PackageViewModel>(serviceId));
        }
    }
}
