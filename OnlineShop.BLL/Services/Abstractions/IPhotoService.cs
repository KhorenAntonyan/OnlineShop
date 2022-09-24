using Microsoft.AspNetCore.Http;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IPhotoService : IBaseService<Photo>
    {
        Task Add(AddPhotoDTO addPhotoDTO);
        Task<List<Photo>> AddFiles(List<IFormFile> photos, int productId);
        Task<GetPhotoDTO> Find(string photoName);
        Task Delete(int photoId);
        Task<int> UpdateMainPhoto(int photoId, int mainPhotoId);
    }
}
