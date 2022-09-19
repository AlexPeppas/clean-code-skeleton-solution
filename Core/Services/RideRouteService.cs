
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

        public async Task<RideRouteEntity> GetNewRideRouteAsync(Guid id, CancellationToken cancellationToken)
        {

            var ridesRepository = this.repositoryProvider.GetRepository<RidesRepository>();
            var result = await ridesRepository.ReadAsync(id, cancellationToken);
            return (RideRouteEntity)result;
        }
    }
}
