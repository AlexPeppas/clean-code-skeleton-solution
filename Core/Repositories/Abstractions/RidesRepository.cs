using GotSpace.Core;
using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace GotSpaceSolution.Core
{
    public sealed class RidesRepository: BaseRepository<RideEntity>
    {
        public RidesRepository(
            IOrgRepositoryContext context,
            ILogger<RidesRepository> logger) : base(context,logger)
        {
        }

        private ConcurrentDictionary<string, RideEntity> rideStore = new();


        public override async Task CreateAsync(RideEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            rideStore.TryAdd(entity.UserId.ToString(), entity);
            await base.CreateAsync(entity, cancellationToken);
            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies
        }

        public async Task<IEnumerable<RideEntity>> SearchFilteredRidesAsync (FilteredRides filter, CancellationToken cancellationToken)
        {
            if (filter is null)
                return localStore.Select(entity => (RideEntity)entity.Value).ToList();

            if (filter.SourceName is null)
                throw new FilterSourceNameCannotBeNullException();

            var filteredEntities = 
                localStore
                .Where(entity =>((RideEntity)entity.Value).SourceName == filter.SourceName
                       && ((RideEntity)entity.Value).Status == RideEnums.RideStatus.Pending.ToString())
                .Select(entity => (RideEntity)entity.Value)
                .ToList();

            if (filteredEntities.Any())
            {
                if (filter.DestinationName != null)
                {
                    filteredEntities = filteredEntities.Where(entity => entity.DestinationName == filter.DestinationName).ToList();
                }

                if (filter.OnlyWomen != null)
                {
                    filteredEntities = filteredEntities.Where(entity => entity.OnlyWomen == filter.OnlyWomen).ToList();
                }

                if (filter.RideTime != null)
                {
                    filteredEntities = filteredEntities.Where(entity => entity.RideTime >= filter.RideTime).ToList();
                }

                if (filter.AvailableNumberOfSeats != null)
                {
                    filteredEntities = filteredEntities.Where(entity => 
                    (entity.TotalNumberOfSeats - entity.AllocatedNumberOfSeats) >= filter.AvailableNumberOfSeats).ToList();
                }
            }

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies

            return filteredEntities;
        }
    }
}
