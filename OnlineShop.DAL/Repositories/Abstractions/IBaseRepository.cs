using OnlineShop.DAL.Entities;
using System.Linq.Expressions;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        void Remove(TEntity entity);
        TEntity FindById(int id);
    }
}
