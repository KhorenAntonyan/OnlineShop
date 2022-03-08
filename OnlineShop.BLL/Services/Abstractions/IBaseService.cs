using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IBaseService<TEntity> where TEntity : class, IBaseEntity
    {
    }
}
