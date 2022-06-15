using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Services;
using ServiceProvider.Shared.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequirementsController : ControllerBase
    {
        private readonly IRequirementsService requirementsService;

        public RequirementsController(IRequirementsService requirementsService)
        {
            this.requirementsService = requirementsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequirementInputModel inputModel)
        {
            await this.requirementsService.CreateAsync(inputModel);
            return this.Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetAllBy(int id)
        {
            return this.Ok(this.requirementsService.GetAllBy<RequirementViewModel>(id));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.requirementsService.DeleteAsync(id);
            return this.Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRequirementInputModel inputModel)
        {
            await this.requirementsService.UpdateAsync(inputModel);
            return this.Ok();
        }

        [HttpGet("requirement/{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            return this.Ok(await this.requirementsService.GetAsync<UpdateRequirementInputModel>(id));
        }
    }
}
