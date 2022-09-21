using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GotSpaceSolution.Core
{
    public class BookingsRepository : BaseRepository<BookingEntity>
    {
        protected ConcurrentDictionary<Guid, IEnumerable<BookingEntity>> bookingsByUserId = new ConcurrentDictionary<Guid, IEnumerable<BookingEntity>>();
        protected ConcurrentDictionary<Guid, IEnumerable<BookingEntity>> bookingsByRideId = new ConcurrentDictionary<Guid, IEnumerable<BookingEntity>>();

        public async Task CreateAsync(BookingEntity entity, CancellationToken cancellationToken)
        {
            if (bookingsByUserId.TryGetValue(entity.UserId, out var bookingOfUser))
            {
                bookingsByUserId[entity.UserId] = bookingOfUser.Append(entity);
            }
            else
            {
                IEnumerable<BookingEntity> newBookings = new List<BookingEntity>();
                bookingsByUserId.TryAdd(entity.UserId, newBookings.Append(entity));
            }

            if (bookingsByRideId.TryGetValue(entity.RideId, out var bookingOfRide))
            {
                bookingsByRideId[entity.RideId] = bookingOfRide.Append(entity);
            }
            else
            {
                IEnumerable<BookingEntity> newBookings = new List<BookingEntity>();
                bookingsByRideId.TryAdd(entity.RideId, newBookings.Append(entity));
            }

            await base.CreateAsync(entity, cancellationToken);
            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies
        }

        public async Task<IEnumerable<BookingEntity>> ReadAsyncByUserId(Guid userId, CancellationToken cancellationToken)
        {
            if (bookingsByUserId.TryGetValue(userId, out var bookings))
            {
                return bookings;
            }
            return new List<BookingEntity>();
        }

        public async Task<IEnumerable<BookingEntity>> ReadAsyncByRideId(Guid rideId, CancellationToken cancellationToken)
        {
            if (bookingsByRideId.TryGetValue(rideId, out var bookings))
            {
                return bookings;
            }
            return new List<BookingEntity>();
        }
    }
}
