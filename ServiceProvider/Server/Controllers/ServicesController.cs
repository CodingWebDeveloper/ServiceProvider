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

        [HttpPost("create-new")]
        public async Task<IActionResult> Create(CreateServiceInputModel inputModel)
        {
            inputModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            int serviceId = await this.servicesService.CreateAsync(inputModel);
            return this.Ok(serviceId);
        }

        [HttpGet("created-by-user")]
        public IActionResult GetAllBy()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<ServiceViewModel> services = this.servicesService.GetAllBy<ServiceViewModel>(userId);

            foreach (var service in services)
            {
                service.StartingPrice = this.servicesService.GetStartingPrice(service.Id);
                service.Rating = this.servicesService.GetRatingById(service.Id);
            }

            return this.Ok(services);
        }

        [HttpGet("price/{serviceId}")]
        public IActionResult GetStartingPrice([FromRoute]int serviceId)
        {
            return this.Ok(this.servicesService.GetStartingPrice(serviceId));
        }

        [HttpGet("info/{serviceId}")]
        public IActionResult GetById([FromRoute] int serviceId)
        {
            return this.Ok(this.servicesService.GetById<ServiceDetails>(serviceId));
        }

        [HttpGet("unfinished-orders/{serviceId}")]
        public IActionResult GetUnfinishedOrdersBy([FromRoute] int serviceId)
        {
            return this.Ok(this.servicesService.GetUnfinishedOrdersBy(serviceId));
        }

        [HttpPost("publish")]
        public async Task<IActionResult> PublishServiceBy([FromBody]int serviceId)
        {
            await this.servicesService.PublishServiceBy(serviceId);
            return this.Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return this.Ok(this.servicesService.GetAll<ServiceViewModel>());
        }

        [HttpGet("rating/{serviceId}")]
        public IActionResult GetRatingById([FromRoute]int serviceId)
        {
            return this.Ok(this.servicesService.GetRatingById(serviceId));
        }
    }
}
