namespace GotSpaceSolution.Core
{
    public interface IRideService
    {
        Task CreateNewRideAsync(RideEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<RideEntity>> SearchFilteredRidesAsync(FilteredRides filter, CancellationToken cancellationToken);

    }
}