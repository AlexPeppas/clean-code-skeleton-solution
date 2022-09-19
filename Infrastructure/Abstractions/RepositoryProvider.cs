using GotSpace.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GotSpaceSolution.Infrastructure
{
    public sealed class RepositoryProvider: IRepositoryProvider
    {
        private readonly IServiceProvider serviceProvider;

        public RepositoryProvider (IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T GetRepository<T>()
            where T : class, IBaseRepository
        {
            return ActivatorUtilities.CreateInstance<T>(serviceProvider);
        }
    }
}
