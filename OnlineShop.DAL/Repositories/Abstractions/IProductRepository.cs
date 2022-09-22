using OnlineShop.DAL.Entities;
using System.Linq.Expressions;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<Product> GetByFilter(Func<Product, bool> filterQuery);
    }
}
