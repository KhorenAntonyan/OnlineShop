using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DbSet<Product> _dbSetProduct;
        private readonly DbSet<Category> _dbSetCategory;
        public CategoryRepository(OnlineShopDbContext context) : base(context)
        {
            _dbSetProduct = context.Set<Product>();
            _dbSetCategory = context.Set<Category>();
        }

        public override void Delete(Category entity)
        {
            base.Delete(entity);
            List<Product> products = _dbSetProduct.Where(p => p.CategoryId == entity.Id).ToList();
            foreach (Product product in products)
            {
                product.CategoryId = null;
            }
        }
    }
}
