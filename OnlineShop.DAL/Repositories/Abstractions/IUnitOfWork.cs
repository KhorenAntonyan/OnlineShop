using OnlineShop.DAL.Repositories.Implementations;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        CategoryRepository CategoryRepository { get; }
        ProductRepository ProductRepository { get; }
        public void Save();
    }
}
