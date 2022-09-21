
using System.Threading;

namespace GotSpaceSolution.Core
{
    public class BookingService : IBookingService
    {
        private readonly IRepositoryProvider repositoryProvider;

        public BookingService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;
        }

        public async Task CreateNewBookingAsync(BookingEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;

            var bookingRepository = this.repositoryProvider.GetRepository<BookingsRepository>(nameof(BookingsRepository));

            await this.UpdateRideAllocatedSeats(entity.Ride.Id, entity.NumberOfSeats, true, cancellationToken);

            await bookingRepository.CreateAsync(entity, cancellationToken);
        }

        public async void CancelBooking(Guid id, CancellationToken cancellationToken)
        {
            var entity = await this.ReadAsync(id, cancellationToken);
            await this.UpdateRideAllocatedSeats(entity.Ride.Id, entity.NumberOfSeats, false, cancellationToken);
            entity.IsDeleted = true;


            // lookup ride with rideId from bookingENtity.Ride.Id
            // revert number of seats 
            // isDeleted = true for the corresponding booking
        }

        public async Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken)
        {
            var bookingRepository = this.repositoryProvider.GetRepository<BookingsRepository>(nameof(BookingsRepository));
            return await bookingRepository.ReadAsync(id, cancellationToken);
        }

        private async Task UpdateRideAllocatedSeats(Guid rideId, int bookingNumberOfSeats, bool toAdd, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            var ride = await ridesRepository.ReadAsync(rideId, cancellationToken);
            ride.AllocatedNumberOfSeats = toAdd ? ride.AllocatedNumberOfSeats += bookingNumberOfSeats : ride.AllocatedNumberOfSeats -= bookingNumberOfSeats;
        }
    }
}
