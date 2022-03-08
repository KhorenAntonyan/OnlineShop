using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Implementations
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IBaseEntity
    {

    }
}
