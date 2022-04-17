using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IPhotoRepository : IBaseRepository<Photo>
    {
        Photo Find(string photoName);
    }
}
