
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
            var updateSeatsDto = new UpdateSeatsDto
            {
                RideId = entity.RideId,
                BookingNumberOfSeats = entity.NumberOfSeats,
                ToAdd = true
            };
            await this.UpdateRideAllocatedSeats(updateSeatsDto, cancellationToken);

            await bookingRepository.CreateAsync(entity, cancellationToken);
        }

        public async Task CancelBookingAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await this.ReadAsync(id, cancellationToken);
            var updateSeatsDto = new UpdateSeatsDto
            {
                RideId = entity.RideId,
                BookingNumberOfSeats = entity.NumberOfSeats,
                ToAdd = false
            };
            await this.UpdateRideAllocatedSeats(updateSeatsDto, cancellationToken);
            entity.IsDeleted = true;
        }

        public async Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken)
        {
            var bookingRepository = this.repositoryProvider.GetRepository<BookingsRepository>(nameof(BookingsRepository));
            return await bookingRepository.ReadAsync(id, cancellationToken);
        }

        public async Task CancelBookingsByRideIdAsync(Guid rideId, CancellationToken cancellationToken)
        {

        }

        public async Task<bool> UpdateAsync(Guid id, int newNumberOfSeats, CancellationToken cancellationToken)
        {
            var bookingRepository = this.repositoryProvider.GetRepository<BookingsRepository>(nameof(BookingsRepository));
            var bookingEntity = await bookingRepository.ReadAsync(id, cancellationToken);

            var rideRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            var rideEntity = await rideRepository.ReadAsync(bookingEntity.RideId, cancellationToken);
           
            var availableNumberOfSeats = rideEntity.TotalNumberOfSeats - rideEntity.AllocatedNumberOfSeats + bookingEntity.NumberOfSeats;

            if (newNumberOfSeats <= availableNumberOfSeats)
            {
                rideEntity.AllocatedNumberOfSeats = rideEntity.AllocatedNumberOfSeats - bookingEntity.NumberOfSeats + newNumberOfSeats;
                bookingEntity.NumberOfSeats = newNumberOfSeats;
                return true;
            }
            return false;
        }

        private async Task UpdateRideAllocatedSeats(UpdateSeatsDto updateSeatsDto, CancellationToken cancellationToken)
        {
            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>(nameof(RidesRepository));
            var ride = await ridesRepository.ReadAsync(updateSeatsDto.RideId, cancellationToken);
            ride.AllocatedNumberOfSeats = updateSeatsDto.ToAdd
                ? ride.AllocatedNumberOfSeats += updateSeatsDto.BookingNumberOfSeats
                : ride.AllocatedNumberOfSeats -= updateSeatsDto.BookingNumberOfSeats;
        }
    }
}
