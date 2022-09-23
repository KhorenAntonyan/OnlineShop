using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineShopDbContext context;

        public UnitOfWork(OnlineShopDbContext context)
        {
            this.context = context;
        }
        private CategoryRepository categoryRepository;
        private ProductRepository productRepository;
        private PhotoRepository photoRepository;

        public ProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(context);
                }
                return productRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(context);
                }
                return categoryRepository;
            }
        }

        public PhotoRepository PhotoRepository
        {
            get
            {
                if (this.photoRepository == null)
                {
                    this.photoRepository = new PhotoRepository(context);
                }
                return photoRepository;
            }
        }
        public void Save()
        {
            context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
