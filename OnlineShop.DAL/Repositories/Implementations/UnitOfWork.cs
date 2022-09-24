using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopDbContext _context;

        public UnitOfWork(OnlineShopDbContext context)
        {
            _context = context;
        }

        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IPhotoRepository _photoRepository;

        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);

        public IPhotoRepository PhotoRepository => _photoRepository ?? new PhotoRepository(_context);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
