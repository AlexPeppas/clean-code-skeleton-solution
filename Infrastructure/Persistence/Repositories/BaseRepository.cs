using GotSpaceSolution.Common;
using System.Collections.Concurrent;

namespace GotSpaceSolution.Infrastructure
{
    public abstract class BaseRepository<T> : IBaseRepository
        where T : BaseEntity, new()
    {
        protected ConcurrentDictionary<Guid, BaseEntity> localStore = new();

        public virtual async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            if (entity.Timestamp == default)
                entity.Timestamp = DateTime.UtcNow;

            localStore.TryAdd(entity.Id, entity);

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies
        }

        public virtual async Task<T> ReadAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id == Guid.Empty)
                throw new EntityIdentifierException(nameof(T));

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies

            if (localStore.TryGetValue(id, out var entity))
            {
                if (entity.IsDeleted)
                    throw new EntityNotFoundException(entity.Id); //entity has been deleted

                return (T)entity;
            }
            else
            {
                return new T();
            }
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellation)
        {
            if (entity.Id == Guid.Empty)
                throw new EntityIdentifierException(nameof(T));

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies

            if (localStore.TryGetValue(entity.Id, out var retrievedEntity))
            {
                localStore[entity.Id] = entity;
            }
            else
            {
                throw new EntityNotFoundException(entity.Id);
            }

        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            if (id == Guid.Empty)
                throw new EntityIdentifierException(nameof(T));

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies

            if (localStore.TryGetValue(id, out var retrievedEntity))
            {
                retrievedEntity.IsDeleted = true;
                localStore[id] = retrievedEntity;
            }
            else
            {
                throw new EntityNotFoundException(id);
            }

        }
    }
}
