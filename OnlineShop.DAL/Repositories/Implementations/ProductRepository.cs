using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(OnlineShopDbContext context) : base(context)
        {
            _dbSet = context.Set<Product>();
        }

        public override IQueryable<Product> GetAll()
        {
            return _dbSet
                .Include(p => p.Photos)
                .Include(c => c.Category)
                .Where(p => p.IsDeleted == null)
                .ToList()
                .AsQueryable();
        }

        public override Product FindById(int id)
        {
            return _dbSet
                .Include(p => p.Photos)
                .Include(c => c.Category)
                .FirstOrDefault(p => p.Id == id && p.IsDeleted == null);
        }
    }
}
