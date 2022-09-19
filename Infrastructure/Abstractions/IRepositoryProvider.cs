using GotSpace.Infrastructure;

namespace GotSpaceSolution.Infrastructure
{
    public interface IRepositoryProvider
    {
        T GetRepository<T>()
            where T : class, IBaseRepository;
    }
}