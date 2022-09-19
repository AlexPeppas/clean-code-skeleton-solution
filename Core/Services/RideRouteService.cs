
using GotSpace.Infrastructure;
using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using Infrastructure.Persistence.Repositories;

namespace GotSpaceSolution.Core
{
    public class RideRouteService : IRideRouteService
    {
        private readonly IRepositoryProvider repositoryProvider;

        public RideRouteService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;
        }

        public async Task CreateNewRideRouteAsync(RideRouteEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;

            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>();
            await ridesRepository.CreateAsync(entity, cancellationToken);
        }
    }
}
