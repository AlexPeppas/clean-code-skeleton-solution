
namespace GotSpaceSolution.Core
{
    public interface IUserService
    {
        Task CreateNewUserAsync(UserEntity entity, CancellationToken cancellationToken);

        Task<UserEntity> ReadByUserNameAsync(string userName, CancellationToken cancellationToken);

        Task<UserEntity> LoginUserAsync(string userName, string password, CancellationToken cancellationToken);

        Task<UserEntity> ReadByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    }
}
