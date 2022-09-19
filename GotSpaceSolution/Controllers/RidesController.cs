using GotSpaceSolution.Core;
using Microsoft.AspNetCore.Mvc;

namespace GotSpaceSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RidesController : ControllerBase
    {
        private readonly ILogger<RidesController> logger;
        private readonly IRideService rideRouteService;

        public RidesController(ILogger<RidesController> logger, IRideService rideRouteService)
        {
            this.logger = logger;
            this.rideRouteService = rideRouteService;
        }

        [HttpPost(Name = "CreateRouteRide")]
        public async Task<IActionResult> CreateRouteRide (CreateRideRoute entity, CancellationToken cancellationToken = default)
        {
            var dbEntiy = new RideEntity 
            { 
                DestinationName = entity.DestinationName,
                SourceName = entity.SourceName,
                NumberOfSeats = entity.PassengersCount
            };

            await rideRouteService.CreateNewRideAsync(dbEntiy, cancellationToken);

            return Ok();
        }
    }
}