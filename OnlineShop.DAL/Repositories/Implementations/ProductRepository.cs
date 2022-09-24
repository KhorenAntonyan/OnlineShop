using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(OnlineShopDbContext context) : base(context)
        {
            _dbSet = context.Set<Product>();
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return _dbSet
                .Include(p => p.Photos)
                .Include(c => c.Category)
                .ToList();
        }

        public override async Task<Product> FindByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Photos)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
