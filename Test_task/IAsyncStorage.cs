namespace ConsoleApp30
{
    public interface IAsyncStorage<T>
    {
        Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken = default);
        Task<int> SetAsync(IEnumerable<T> items, CancellationToken cancellationToken = default);
    }
}
