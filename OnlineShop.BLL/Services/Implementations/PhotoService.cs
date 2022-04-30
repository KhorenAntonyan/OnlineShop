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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PhotoService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }
        public void Add(AddPhotoDTO addPhotoDTO)
        {
            var photo = _mapper.Map<Photo>(addPhotoDTO);
            unitOfWork.PhotoRepository.Add(photo);
            unitOfWork.Save();
        }

        public List<Photo> AddFiles(List<IFormFile> photos, int productId)
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

        public GetPhotoDTO Find(string photoName)
        {
            var photo = _mapper.Map<GetPhotoDTO>(unitOfWork.PhotoRepository.Find(photoName));
            return photo;
        }

        public void Remove(int photoId)
        {
            Photo photo = unitOfWork.PhotoRepository.FindById(photoId);
            unitOfWork.PhotoRepository.Remove(photo);
            unitOfWork.Save();
        }

        public void Update(UpdatePhotoDTO updatePhotoDTO)
        {
            var updatePhotos = _mapper.Map<Photo>(updatePhotoDTO);
            unitOfWork.PhotoRepository.Update(updatePhotos);
            unitOfWork.Save();
        }
    }
}
