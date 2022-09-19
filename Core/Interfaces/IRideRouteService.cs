namespace GotSpaceSolution.Core
{
    public interface IRideRouteService
    {
        Task CreateNewRideRouteAsync(RideRouteEntity entity, CancellationToken cancellationToken);

        Task<RideRouteEntity> GetNewRideRouteAsync(Guid id, CancellationToken cancellationToken);
    }
}