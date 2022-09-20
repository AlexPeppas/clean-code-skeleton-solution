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

        [HttpPost("/CreateUser")]
        public async Task<IActionResult> CreateUser(UserEntity entity, CancellationToken cancellationToken = default)
        {
            await userService.CreateNewUserAsync(entity, cancellationToken);
            return Ok();
        }

        [HttpGet ("/GetUser")]
        public async Task<IActionResult> GetUser(string userName, CancellationToken cancellationToken = default)
        {
            var userEntity = await userService.ReadAsyncByUserName(userName, cancellationToken);
            return Ok(userEntity);
        }
    }
}
