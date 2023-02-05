using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.BLL.Services.Implementations
{
    public class PhotoService : BaseService<Photo>, IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PhotoService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task Add(AddPhotoDTO addPhotoDTO)
        {
            var photo = _mapper.Map<Photo>(addPhotoDTO);
            await _unitOfWork.PhotoRepository.AddAsync(photo);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Photo>> AddFiles(List<IFormFile> photos, int productId)
        {
            List<Photo> photoList = new List<Photo>();

            if (photos.Count() > 0)
            {
                for (int i = 0; i < photos.Count(); i++)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(photos[i].FileName);
                    string extension = Path.GetExtension(photos[i].FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/img", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        photos[i].CopyTo(fileStream);
                    }

                    photoList.Add(new Photo
                    {
                        PhotoURL = fileName,
                        ProductId = productId,
                        IsMain = i == photos.Count() - 1 ? true : false
                    });

                    if (productId != 0)
                    {
                        Add(new AddPhotoDTO
                        {
                            PhotoURL = fileName,
                            ProductId = productId,
                            IsMain = i == photos.Count() - 1 ? true : false
                        });
                    }
                }
            }

            return photoList;
        }

        public async Task<GetPhotoDTO> Find(string photoName)
        {
            var photo = _mapper.Map<GetPhotoDTO>(await _unitOfWork.PhotoRepository.FindAsync(photoName));
            return photo;
        }

        public async Task Delete(int photoId)
        {
            Photo photo = await _unitOfWork.PhotoRepository.FindByIdAsync(photoId);
            await _unitOfWork.PhotoRepository.DeleteAsync(photo);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> UpdateMainPhoto(UpdateMainPhotoDTO updateMainPhotoDTO)
        {
            Photo updatePhoto = await _unitOfWork.PhotoRepository.FindByIdAsync(updateMainPhotoDTO.PhotoId);
            Photo updateMainPhoto = await _unitOfWork.PhotoRepository.FindByIdAsync(updateMainPhotoDTO.MainPhotoId);
            updatePhoto.IsMain = true;
            updateMainPhoto.IsMain = false;
            await _unitOfWork.PhotoRepository.UpdateAsync(updatePhoto);
            await _unitOfWork.PhotoRepository.UpdateAsync(updateMainPhoto);
            await _unitOfWork.SaveChangesAsync();
            
            return updatePhoto.ProductId;
        }
    }
}
