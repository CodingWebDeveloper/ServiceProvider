using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Services;
using ServiceProvider.Shared.Skills;
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
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            this.skillsService = skillsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddSkill(AddSkillInputModel inputModel)
        {
            inputModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.skillsService.AddSkill(inputModel);
            return this.Ok();
        }

        [HttpGet("userSkills")]
        public IActionResult GetAll()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return this.Ok(this.skillsService.GetAllBy<SkillViewModel>(userId));
        }
    }
}
