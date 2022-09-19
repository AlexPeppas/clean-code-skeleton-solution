namespace GotSpaceSolution.Core
{
    public interface IRideService
    {
        Task CreateNewRideAsync(RideEntity entity, CancellationToken cancellationToken);

    }
}