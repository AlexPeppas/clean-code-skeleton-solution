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

        [HttpPost("/createRouteRide")]
        public async Task<IActionResult> CreateRouteRide (CreateRide entity, CancellationToken cancellationToken = default)
        {
            
            var dbEntiy = new RideEntity 
            { 
                DestinationName = entity.DestinationName,
                SourceName = entity.SourceName,
                AllocatedNumberOfSeats = entity.AllocatedNumberOfSeats,
                TotalNumberOfSeats = entity.TotalNumberOfSeats,
                OnlyWomen = entity.OnlyWomen,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = entity.CreatedBy,
                RideTime = entity.RideActivation,
            };

            await rideRouteService.CreateNewRideAsync(dbEntiy, cancellationToken);

            return Ok();
        }

        [HttpPost("/searchFilteredRides")]
        public async Task<IActionResult> SearchFilteredRidesAsync(FilteredRides filter, CancellationToken cancellationToken)
        {
            var rides = await rideRouteService.SearchFilteredRidesAsync(filter, cancellationToken);
            
            return Ok(rides);
        }

        [HttpPost("/cancelRide")]
        public async Task<IActionResult> SearchFilteredRidesAsync(Guid rideId, CancellationToken cancellationToken)
        {
            var canceled = await rideRouteService.CancelRide(rideId, cancellationToken);

            if (canceled)
                return Ok();

            return NotFound($"Ride with Id : {rideId} does not exist");
        }

        [HttpPost("/joinRide")]
        public async Task<IActionResult> JoinRide(JoinRide joinOptions, CancellationToken cancellationToken)
        {
            var joined = await rideRouteService.JoinRide(joinOptions, cancellationToken);

            if (joined)
                return Ok();

            return BadRequest("There are not sufficient seats for your request");
        }
    }
}