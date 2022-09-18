using GotSpaceSolution.Common;

namespace GotSpace.Infrastructure
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task CreateAsync(T entity, CancellationToken cancellationToken);

        Task<T> ReadAsync(Guid id, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellation);

        Task DeleteAsync(Guid id, CancellationToken cancellation);
    }
}