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
        private readonly ICloudinaryService cloudinaryService;

        public ApplicationUsersController(
            IApplicationUsersService applicationUsersService,
            ICloudinaryService cloudinaryService)
        {
            this.applicationUsersService = applicationUsersService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("by-id")]
        public IActionResult GetById()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            UserViewModel viewModel = this.applicationUsersService.GetById<UserViewModel>(userId);
            viewModel.Rating = this.applicationUsersService.CalculateRating(userId);
            return this.Ok(viewModel);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] EditUserInputModel inputModel)
        {

            inputModel.NewProfileImageUrl = await this.cloudinaryService.UploadPicture(inputModel.NewProfileImageByteArr,"user-image");

            await this.applicationUsersService.UpdateAsync(inputModel);

            return this.Ok();
        }

        //[HttpGet("by-id/calc-rating")]
        //public IActionResult GetCalculatedRating()
        //{
        //    string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    return this.Ok(this.applicationUsersService.CalculateRating(userId));
        //}
    }
}
