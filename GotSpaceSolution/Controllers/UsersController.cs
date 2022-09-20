using GotSpaceSolution.Core;
using Microsoft.AspNetCore.Mvc;

namespace GotSpaceSolution.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UsersController : Controller
    {

        private readonly ILogger<UsersController> logger;
        private readonly IUserService userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateUser(UserEntity entity, CancellationToken cancellationToken = default)
        {
            await userService.CreateNewUserAsync(entity, cancellationToken);
            return Ok();
        }
    }
}
