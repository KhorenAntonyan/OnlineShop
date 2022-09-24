
namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        Task SaveChangesAsync();
    }
}
