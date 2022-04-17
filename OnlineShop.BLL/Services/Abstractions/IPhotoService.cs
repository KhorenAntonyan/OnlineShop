using Microsoft.AspNetCore.Http;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IPhotoService : IBaseService<Photo>
    {
        void Add(AddPhotoDTO addPhotoDTO);
        IEnumerable<GetPhotoDTO> AddFiles(IEnumerable<IFormFile> photos, int productId);
        GetPhotoDTO Find(string photoName);
        void Remove(int photoId);
    }
}
