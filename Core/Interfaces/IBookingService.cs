namespace GotSpaceSolution.Core
{
    public interface IBookingService
    {
        Task CreateNewBookingAsync(BookingEntity entity, CancellationToken cancellationToken);

        Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<BookingEntity>> ReadAsyncByUserId(Guid userId, CancellationToken cancellationToken);

        Task<IEnumerable<BookingEntity>> ReadAsyncByRideId(Guid rideId, CancellationToken cancellationToken);

        Task CancelBookingAsync(Guid id, CancellationToken cancellationToken);

        Task<bool> UpdateAsync(Guid id, int newNumberOfSeats, CancellationToken cancellationToken);

        Task CancelBookingsByRideIdAsync (Guid rideId, CancellationToken cancellationToken);
    }
}