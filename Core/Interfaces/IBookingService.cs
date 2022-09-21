﻿namespace GotSpaceSolution.Core
{
    public interface IBookingService
    {
        Task CreateNewBookingAsync(BookingEntity entity, CancellationToken cancellationToken);

        Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken);

        Task CancelBookingAsync(Guid id, CancellationToken cancellationToken);

        Task<bool> UpdateAsync(Guid id, int newNumberOfSeats, CancellationToken cancellationToken);

        Task CancelBookingsByRideIdAsync (Guid rideId, CancellationToken cancellationToken);
    }
}