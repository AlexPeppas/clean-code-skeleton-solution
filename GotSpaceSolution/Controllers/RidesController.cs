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

        [HttpPost(Name = "CreateRouteRide")]
        public async Task<IActionResult> CreateRouteRide (CreateRideRoute entity, CancellationToken cancellationToken = default)
        {
            var dbEntiy = new RideRouteEntity 
            { 
                DestinationName = entity.DestinationName,
                SourceName = entity.SourceName,
                PassengersCount = entity.PassengersCount
            };

            await rideRouteService.CreateNewRideRouteAsync(dbEntiy, cancellationToken);

            return Ok();
        }

        [HttpGet(Name = "GetRouteRide")]
        public async Task<IActionResult> GetRouteRide(Guid id, CancellationToken cancellationToken = default)
        {

            var result = await rideRouteService.GetNewRideRouteAsync(id, cancellationToken);

            return Ok(result);
        }
    }
}