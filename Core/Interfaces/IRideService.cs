namespace GotSpaceSolution.Core
{
    public interface IRideService
    {
        Task CreateNewRideAsync(RideEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<RideEntity>> SearchFilteredRidesAsync(FilteredRides filter, CancellationToken cancellationToken);

        Task<bool> CancelRide(Guid id, CancellationToken cancellationToken);

        Task<bool> JoinRide(JoinRide joinOptions, CancellationToken cancellationToken);

    }
}