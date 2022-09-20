
namespace GotSpaceSolution.Infrastructure
{
    public interface IRepositoryProvider
    {
        T GetRepository<T>(string repositoryName)
            where T : class, IBaseRepository;
    }
}