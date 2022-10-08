using GotSpace.Core;
using GotSpaceSolution.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace GotSpaceSolution.Core
{
    public sealed class RepositoryProvider: IRepositoryProvider
    {
        private readonly IServiceProvider serviceProvider;
        private ConcurrentDictionary<(Type, IOrgRepositoryContext),IBaseRepository> repositoryCache = new();

        public RepositoryProvider (IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T GetRepository<T>(
            IOrgRepositoryContext context)
            where T : class, IBaseRepository
        {
            var cacheKey = (typeof(T), context);

            return (T) repositoryCache.GetOrAdd(cacheKey, ActivatorUtilities.CreateInstance<T>(serviceProvider));
            
        }
    }
}
