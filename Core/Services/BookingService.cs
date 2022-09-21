
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
            await bookingRepository.CreateAsync(entity, cancellationToken);
        }

        public void CancelBooking()
        {
            // lookup ride with rideId from bookingENtity.Ride.Id
            // revert number of seats 
            // isDeleted = true for the corresponding booking
        }

        public async Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken)
        {
            var bookingRepository = this.repositoryProvider.GetRepository<BookingsRepository>(nameof(BookingsRepository));
            return await bookingRepository.ReadAsync(id, cancellationToken);
        }
    }
}
