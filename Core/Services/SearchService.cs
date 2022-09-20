using GotSpaceSolution.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SearchService
    {
        private readonly IRepositoryProvider repositoryProvider;

        public SearchService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;
        }
    }
}
