namespace GotSpaceSolution.Core
{
    public interface IRideRouteService
    {
        Task CreateNewRideRouteAsync(RideRouteEntity entity, CancellationToken cancellationToken);
    }
}