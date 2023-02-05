using OnlineShop.DAL.Entities;
using System.Linq.Expressions;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetByFilterAsync(Func<Product, bool> filterQuery);
    }
}
