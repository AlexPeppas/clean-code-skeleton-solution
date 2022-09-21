
using GotSpace.Infrastructure;
using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using System.Security.Principal;

namespace GotSpaceSolution.Core
{
    public class RideService : IRideService
    {
        private readonly IRepositoryProvider repositoryProvider;
        private readonly IBookingService bookingService;
        private readonly IUserService userService;

        public RideService(IRepositoryProvider repositoryProvider, IBookingService bookingService, IUserService userService)
        {
            this.repositoryProvider = repositoryProvider;
            this.bookingService = bookingService;
            this.userService = userService;
        }

        public async Task CreateNewRideAsync(RideEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;
            entity.Status = RideEnums.RideStatus.Pending.ToString();
            
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            await ridesRepository.CreateAsync(entity, cancellationToken);

            var user = await this.userService.ReadByUserIdAsync(entity.UserId, cancellationToken);
            
            var booking = new BookingEntity
            {
                NumberOfSeats = entity.AllocatedNumberOfSeats,
                UserId = user.Id,
                RideId = entity.Id
            };
            await this.bookingService.CreateNewBookingAsync(booking, cancellationToken);
        }

        public async Task<bool> JoinRide(JoinRide joinOptions, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
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

                await this.bookingService.CreateNewBookingAsync(booking, cancellationToken);

                ride.AllocatedNumberOfSeats += joinOptions.NumberOfSeatsRequested;
                await ridesRepository.UpdateAsync(ride, cancellationToken);
                
                return true;
            }
            return false;
        }

        public async Task<bool> CancelRide(Guid id, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            var ride = await ridesRepository.ReadAsync(id, cancellationToken);
            
            if (ride is null)
                return false;

            ride.IsDeleted = true;
            await ridesRepository.UpdateAsync(ride, cancellationToken);

            await this.bookingService.CancelBookingsByRideIdAsync(id, cancellationToken);
            
            return true;
        }

        public async Task<IEnumerable<RideEntity>> SearchFilteredRidesAsync(FilteredRides filter, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            return await ridesRepository.SearchFilteredRidesAsync(filter, cancellationToken);
        }
    }
}
