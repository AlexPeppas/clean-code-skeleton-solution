namespace GotSpaceSolution.Infrastructure
{
    public interface IRepositoryContext : IReadOnlyDictionary<string, object>
    {
        IServiceProvider ServiceProvider { get; }

        void SetValue<T>(string key, T value);

        T GetValue<T>(string key);
    }
}