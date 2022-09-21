
using GotSpace.Infrastructure;
using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using System.Security.Principal;

namespace GotSpaceSolution.Core
{
    public class RideService : IRideService
    {
        private readonly IRepositoryProvider repositoryProvider;

        public RideService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;
        }

        public async Task CreateNewRideAsync(RideEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;
            entity.Status = RideEnums.RideStatus.Pending.ToString();
            
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            await ridesRepository.CreateAsync(entity, cancellationToken);
        }

        public void JoinRide()
        {
            //findRideById
            //check if sufficient number of Seats
            //create a new Booking
            
        }

        public void CancelRide()
        {

        }

        public async Task<IEnumerable<RideEntity>> SearchFilteredRidesAsync(FilteredRides filter, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            return await ridesRepository.SearchFilteredRidesAsync(filter, cancellationToken);
        }
    }
}
