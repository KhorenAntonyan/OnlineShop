namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancaletionToken = default);
    }
}
