
namespace GotSpaceSolution.Core
{
    public interface IUserService
    {
        Task CreateNewUserAsync(UserEntity entity, CancellationToken cancellationToken);
    }
}
