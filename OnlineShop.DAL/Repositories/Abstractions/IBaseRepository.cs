using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        void Delete(TEntity entity);
        TEntity FindById(int id);
    }
}
