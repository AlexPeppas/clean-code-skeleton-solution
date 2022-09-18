
using GotSpace.Infrastructure;

namespace GotSpaceSolution.Core
{
    public class RideRouteService : IRideRouteService
    {
        private readonly IBaseRepository<RideRouteEntity> repository;

        public RideRouteService(IBaseRepository<RideRouteEntity> repository)
        {
            this.repository = repository;
        }

        public async Task CreateNewRideRouteAsync(RideRouteEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;

            await repository.CreateAsync(entity, cancellationToken);
        }
    }
}
