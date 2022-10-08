using GotSpace.Core;
using GotSpace.Infrastructure;
using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using System.Security.Principal;

namespace GotSpaceSolution.Core
{
    public class RideService : IRideService
    {
        private readonly IRepositoryProvider repositoryProvider;
        private readonly IOrgRepositoryContext context;

        public RideService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;
        }

        public async Task CreateNewRideAsync(RideEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;
            entity.Status = RideEnums.RideStatus.Pending.ToString();
            
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(context);
            await ridesRepository.CreateAsync(entity, cancellationToken);
        }

        public async Task<bool> JoinRide(JoinRide joinOptions, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(context);
            var ride = await ridesRepository.ReadAsync(joinOptions.RideId, cancellationToken);
            var availableNumberOfSeats = ride.TotalNumberOfSeats - ride.AllocatedNumberOfSeats;
            
            if (joinOptions.NumberOfSeatsRequested <= availableNumberOfSeats)
            {
                var booking = new BookingEntity
                {
                    NumberOfSeats = joinOptions.NumberOfSeatsRequested,
                    UserId = joinOptions.User.Id,
                    RideId = ride.Id
                };

                ride.AllocatedNumberOfSeats += joinOptions.NumberOfSeatsRequested;
                await ridesRepository.UpdateAsync(ride, cancellationToken);
                
                return true;
            }
            return false;
        }

        public async Task<bool> CancelRide(Guid id, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(context);
            var ride = await ridesRepository.ReadAsync(id, cancellationToken);
            
            if (ride is null)
                return false;

            ride.IsDeleted = true;
            await ridesRepository.UpdateAsync(ride, cancellationToken);
            
            return true;
        }

        public async Task<IEnumerable<RideEntity>> SearchFilteredRidesAsync(FilteredRides filter, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(context);
            return await ridesRepository.SearchFilteredRidesAsync(filter, cancellationToken);
        }
    }
}
