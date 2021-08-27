using Microsoft.AspNetCore.Mvc;
using ServiceProvider.Server.Services;
using ServiceProvider.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceProvider.Server.Controllers
{
    [ApiController]
    [Route("api/application-users")]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IApplicationUsersService applicationUsersService;

        public ApplicationUsersController(IApplicationUsersService applicationUsersService)
        {
            this.applicationUsersService = applicationUsersService;
        }

        public IActionResult GetById()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return this.Ok(this.applicationUsersService.GetById<UserViewModel>(userId));
        }
    }
}
