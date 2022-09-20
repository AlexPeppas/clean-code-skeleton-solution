using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;


namespace GotSpaceSolution.Core
{
    public class RidesRepository : BaseRepository<RideEntity>
    {
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

                if (filter.NumberOfSeats != null)
                {
                    filteredEntities = filteredEntities.Where(entity => entity.NumberOfSeats >= filter.NumberOfSeats).ToList();
                }
            }

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies

            return filteredEntities;
        }
    }
}
