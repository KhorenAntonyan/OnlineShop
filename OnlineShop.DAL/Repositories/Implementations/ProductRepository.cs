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

        public override IQueryable<Product> GetAll()
        {
            return _dbSet
                .Include(p => p.Photos)
                .Include(c => c.Category)
                .Where(p => p.IsDeleted == null)
                .AsQueryable();
        }

        public IEnumerable<Product> GetByFilter(Func<Product, bool> filterQuery)
        {
            var query = _dbSet
                .Include(p => p.Photos)
                .Include(c => c.Category)
                .Where(filterQuery);

            var list = query.ToList();

            return list;
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
