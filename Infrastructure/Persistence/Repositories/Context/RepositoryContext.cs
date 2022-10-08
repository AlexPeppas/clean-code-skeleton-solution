using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GotSpaceSolution.Infrastructure
{
    public abstract class RepositoryContext<T> :
        Dictionary<string, object>,
        IRepositoryContext,
        IEquatable<T>
        where T : class, IRepositoryContext
    {
        public RepositoryContext(IServiceProvider serviceProvider)
        {
            Validations.CheckValue(serviceProvider, nameof(serviceProvider));
            this.ServiceProvider = serviceProvider;
        }

        private static readonly object defaultState = new();
        
        public IServiceProvider ServiceProvider { get;}

        public T GetValue<T>(string key)
        {
            Validations.CheckNonWhiteSpace(key, nameof(key));

            if (TryGetValue(key, out var value))
            {
                if (value is T typedValue)
                {
                    return typedValue;
                }
                throw new Exception("MAKE THIS CUSTOM EXCEPTION, MISMATCH OF TYPES EXCEPTION");
            }

            throw new ArgumentNullException(nameof(key));
        }

        public void SetValue<T>(string key, T value)
        {
            Validations.CheckNonWhiteSpace(key, nameof(key));

            Add(key, value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public bool Equals(T other)
        {
            return ReferenceEquals(this, other)
                || GetHashCode() == other?.GetHashCode();
        }

        public override int GetHashCode()
        {
            if (Count == 0)
            {
                return defaultState.GetHashCode();
            }

            var hash = default(HashCode);

            foreach (var (key, value) in this)
            {
                hash.Add(
                    HashCode.Combine(key, value));
            }

            return hash.ToHashCode();
        }
    }
}
