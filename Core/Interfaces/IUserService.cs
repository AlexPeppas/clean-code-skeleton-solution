
namespace GotSpaceSolution.Core
{
    public interface IUserService
    {
        Task<UserEntity> CreateNewUserAsync(UserEntity entity, CancellationToken cancellationToken);

        Task<UserEntity> ReadAsyncByUserName(string userName, CancellationToken cancellationToken);

        Task<UserEntity> LoginUserAsync(string userName, string password, CancellationToken cancellationToken);

    }
}
