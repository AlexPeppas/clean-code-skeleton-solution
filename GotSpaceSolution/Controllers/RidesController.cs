using GotSpaceSolution.Core;
using Microsoft.AspNetCore.Mvc;

namespace GotSpaceSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RidesController : ControllerBase
    {
        private readonly ILogger<RidesController> logger;
        private readonly IRideRouteService rideRouteService;

        public RidesController(ILogger<RidesController> logger, IRideRouteService rideRouteService)
        {
            this.logger = logger;
            this.rideRouteService = rideRouteService;
        }

        [HttpGet(Name = "CreateRouteRide")]
        public async Task<IActionResult> CreateRouteRide (RideRouteEntity entity, CancellationToken cancellationToken = default)
        {
            await rideRouteService.CreateNewRideRouteAsync(entity, cancellationToken);

            return Ok();
        }
    }
}