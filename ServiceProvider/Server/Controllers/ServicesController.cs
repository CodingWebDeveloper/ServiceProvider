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
            IEnumerable<ServiceViewModel> services = this.servicesService.GetAllBy<ServiceViewModel>(userId);

            return this.Ok(services);
        }

        [HttpGet("price/{serviceId}")]
        public IActionResult GetStartingPrice([FromRoute]int serviceId)
        {
            return this.Ok(this.servicesService.GetStartingPrice(serviceId));
        }

        [HttpGet("service-info/{serviceId}")]
        public IActionResult GetById([FromRoute] int serviceId)
        {
            return this.Ok(this.servicesService.GetById<ServiceInfoViewModel>(serviceId));
        }

        [HttpGet("service-unfinished-orders/{serviceId}")]
        public IActionResult GetUnfinishedOrdersBy([FromRoute] int serviceId)
        {
            return this.Ok(this.servicesService.GetUnfinishedOrdersBy(serviceId));
        }

        [HttpPost("publish-service")]
        public async Task<IActionResult> PublishServiceBy([FromBody]int serviceId)
        {
            await this.servicesService.PublishServiceBy(serviceId);
            return this.Ok();
        }
    }
}
