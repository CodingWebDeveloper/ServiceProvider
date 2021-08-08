using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Services;
using ServiceProvider.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceInputModel inputModel)
        {
            inputModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int serviceId = await this.servicesService.CreateAsync(inputModel);
            return this.Ok(serviceId);
        }

        [HttpGet]
        public IActionResult GetAllBy()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return this.Ok(this.servicesService.GetAllBy<ServiceViewModel>(userId));
        }
    }
}
