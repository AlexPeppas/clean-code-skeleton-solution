using GotSpace.Core;
using GotSpaceSolution.Infrastructure;

namespace GotSpaceSolution.Core
{
    public interface IRepositoryProvider
    {
        T GetRepository<T>(IOrgRepositoryContext context)
            where T : class, IBaseRepository;
    }
}