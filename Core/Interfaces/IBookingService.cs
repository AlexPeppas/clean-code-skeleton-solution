namespace GotSpaceSolution.Core
{
    public interface IBookingService
    {
        Task CreateNewBookingAsync(BookingEntity entity, CancellationToken cancellationToken);

        Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken);
    }
}