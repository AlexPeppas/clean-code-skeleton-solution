
using GotSpaceSolution.Infrastructure;

namespace GotSpaceSolution.Core
{
    public interface IRepositoryProvider
    {
        T GetRepository<T>(string repositoryName)
            where T : class, IBaseRepository;
    }
}