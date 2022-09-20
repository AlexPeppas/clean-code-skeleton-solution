using GotSpaceSolution.Common;
using GotSpaceSolution.Infrastructure;
using System.Collections.Concurrent;

namespace GotSpaceSolution.Core
{

    public class UsersRepository : BaseRepository<UserEntity>
    {
        private ConcurrentDictionary<string, UserEntity> userStore = new();

  
        public override async Task<UserEntity> CreateAsync(UserEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            userStore.TryAdd(entity.UserName, entity);
            await base.CreateAsync(entity, cancellationToken);
            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies
            return entity;
        }

        public async Task<UserEntity> ReadAsyncByUserName(string userName, CancellationToken cancellationToken)
        {
            if (userName is null)
                throw new EntityIdentifierException(nameof(UserEntity));

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies

            if (userStore.TryGetValue(userName, out var entity))
            {
                if (entity.IsDeleted)
                    throw new EntityNotFoundException(entity.Id); //entity has been deleted

                return entity;
            }

            throw new Exception($"User Entity with {userName} is not found"); //entity has been deleted

        }

        public async Task<UserEntity> LoginUserAsync(string userName, string password, CancellationToken cancellationToken)
        {
            if (userName is null || password is null)
                throw new EntityIdentifierException(nameof(UserEntity));

            await Task.CompletedTask; // dummy to trick async with await. Remove when actualy SQL integration applies

            if (userStore.TryGetValue(userName, out var entity))
            {
                if (entity.IsDeleted)
                    throw new EntityNotFoundException(entity.Id); //entity has been deleted

                if (entity.Passsword != password)
                    throw new Exception("either incorrect username or/and password were provided");

                return entity;
            }

            throw new Exception("either incorrect username or/and password were provided");
        }
    }

}
