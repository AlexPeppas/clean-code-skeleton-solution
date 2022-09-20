using GotSpace.Infrastructure;
using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using GotSpaceSolution.Infrastrucutre;


namespace GotSpaceSolution.Core
{
    public class UserService : IUserService
    {
        private readonly IRepositoryProvider repositoryProvider;

        public UserService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;

        }

        public async Task CreateNewUserAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;
            var userRepository = this.repositoryProvider.GetRepository<UsersRepository>(nameof(UsersRepository));
            await userRepository.CreateAsync(entity, cancellationToken);
        }
    }
}
