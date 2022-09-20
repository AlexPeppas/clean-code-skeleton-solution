
namespace GotSpaceSolution.Core
{
    public class UserService : IUserService
    {
        private readonly IRepositoryProvider repositoryProvider;

        public UserService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;

        }

        public async Task<UserEntity> CreateNewUserAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            entity.Timestamp = DateTime.UtcNow;
            entity.IsDeleted = false;
            var userRepository = this.repositoryProvider.GetRepository<UsersRepository>(nameof(UsersRepository));
            var entityCreated = await userRepository.CreateAsync(entity, cancellationToken);
            return entityCreated;
        }

        public async  Task<UserEntity>ReadAsyncByUserName(string userName, CancellationToken cancellationToken)
        {
            var userRepository = this.repositoryProvider.GetRepository<UsersRepository>(nameof(UsersRepository));
            return await userRepository.ReadAsyncByUserName(userName, cancellationToken);
        }

        public async Task<UserEntity> LoginUserAsync(string userName, string password, CancellationToken cancellationToken)
        {
            var userRepository = this.repositoryProvider.GetRepository<UsersRepository>(nameof(UsersRepository));
            return await userRepository.LoginUserAsync(userName, password, cancellationToken);
        }

    }
}
