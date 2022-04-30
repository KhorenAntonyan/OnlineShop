using Microsoft.AspNetCore.Http;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IPhotoService : IBaseService<Photo>
    {
        void Add(AddPhotoDTO addPhotoDTO);
        List<Photo> AddFiles(List<IFormFile> photos, int productId);
        GetPhotoDTO Find(string photoName);
        void Remove(int photoId);
        void Update(UpdatePhotoDTO updatePhotoDTO);
    }
}
