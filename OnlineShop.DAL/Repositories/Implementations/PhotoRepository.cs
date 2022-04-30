using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        private readonly DbSet<Photo> _dbSet;
        public PhotoRepository(OnlineShopDbContext context) : base(context)
        {
            _dbSet = context.Set<Photo>();
        }

        public Photo Find(string photoName)
        {
            return _dbSet.FirstOrDefault(p => p.PhotoURL == photoName);
        }

    }
}
