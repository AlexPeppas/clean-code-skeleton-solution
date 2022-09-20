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

        public RidesController(ILogger<RidesController> logger, IRideService rideService)
        {
            this.logger = logger;
            this.rideRouteService = rideService;
        }

        [HttpPost("/CreateRouteRide")]
        public async Task<IActionResult> CreateRouteRide (CreateRide entity, CancellationToken cancellationToken = default)
        {
            
            var dbEntiy = new RideEntity 
            { 
                DestinationName = entity.DestinationName,
                SourceName = entity.SourceName,
                NumberOfSeats = entity.NumberOfSeats,
                OnlyWomen = entity.OnlyWomen,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = entity.CreatedBy,
                RideTime = entity.RideActivation,
            };

            await rideRouteService.CreateNewRideAsync(dbEntiy, cancellationToken);

            return Ok();
        }
    }
}