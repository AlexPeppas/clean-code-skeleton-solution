namespace GotSpaceSolution.Core
{
    public interface IBookingService
    {
        Task<BookingEntity> CreateNewBookingAsync(BookingEntity entity, CancellationToken cancellationToken);

        Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken);
    }
}