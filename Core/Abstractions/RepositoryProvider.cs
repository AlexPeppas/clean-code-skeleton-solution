using GotSpaceSolution.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace GotSpaceSolution.Core
{
    public sealed class RepositoryProvider: IRepositoryProvider
    {
        private readonly IServiceProvider serviceProvider;
        private ConcurrentDictionary<string,IBaseRepository> repositoryCache = new();

        public RepositoryProvider (IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T GetRepository<T>(string repositoryName)
            where T : class, IBaseRepository
        {
            return (T) repositoryCache.GetOrAdd(repositoryName, ActivatorUtilities.CreateInstance<T>(serviceProvider));
            
        }
    }
}
