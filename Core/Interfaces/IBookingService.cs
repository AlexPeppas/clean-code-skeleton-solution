namespace GotSpaceSolution.Core
{
    public interface IBookingService
    {
        Task CreateNewBookingAsync(BookingEntity entity, CancellationToken cancellationToken);
    }
}