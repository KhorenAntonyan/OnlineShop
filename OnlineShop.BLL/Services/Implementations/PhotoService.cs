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

        public IEnumerable<GetPhotoDTO> AddFiles(IEnumerable<IFormFile> photos, int productId)
        {
            List<GetPhotoDTO> photoList = new List<GetPhotoDTO>();

            if (photos.Count() > 0)
            {
                foreach (var photo in photos)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(photo.FileName);
                    string extension = Path.GetExtension(photo.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/img", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }

                    photoList.Add(new GetPhotoDTO
                    {
                        PhotoURL = fileName,
                        ProductId = productId
                    });

                    if(productId != 0)
                    {
                        Add(new AddPhotoDTO
                        {
                            PhotoURL = fileName,
                            ProductId = productId
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
    }
}
