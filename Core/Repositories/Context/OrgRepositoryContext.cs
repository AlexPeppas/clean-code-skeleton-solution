using Common;
using GotSpaceSolution.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GotSpace.Core
{
    public sealed class OrgRepositoryContext :
        RepositoryContext<OrgRepositoryContext>,
        IOrgRepositoryContext
    {
        public OrgRepositoryContext(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Validations.CheckValue(serviceProvider, nameof(serviceProvider));
            this.ServiceProvider = serviceProvider;
            //profilId in context
        }

        private static readonly object defaultState = new();
        
        public IServiceProvider ServiceProvider { get;}

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), defaultState);
        }
    }
}
