using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using System.Collections.Concurrent;

namespace GotSpaceSolution.Core
{
    public class BookingsRepository : BaseRepository<BaseEntity>
    {
        private ConcurrentDictionary<Guid, BookingEntity> bookingStore = new();

        public async Task<BookingEntity> CreateAsync(BookingEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            bookingStore.TryAdd(entity.Id, entity);
            await base.CreateAsync(entity, cancellationToken);
            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies
            return entity;
        }

        public async Task<BookingEntity> ReadAsync(Guid id, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies
            if (id == Guid.Empty)
                throw new EntityIdentifierException(nameof(BookingEntity));


            if (localStore.TryGetValue(id, out var entity))
            {
                if (entity.IsDeleted)
                    throw new EntityNotFoundException(entity.Id); //entity has been deleted

                return (BookingEntity)entity;
            }
            throw new Exception($"Booking Entity with {id} is not found"); //entity has been deleted
        }
    }
}
