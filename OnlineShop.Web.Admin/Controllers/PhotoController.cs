using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Web.Admin.ViewModels.PhotoViewModels;

namespace OnlineShop.Web.Admin.Controllers
{
    public class PhotoController : Controller
    {
        public readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoService photoService, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _photoService = photoService;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
        }

        public IActionResult RemovePhoto(string photoName)
        {
            var photo = _photoService.Find(photoName);

            _photoService.Remove(photo.Id);

            var photoPath = Path.Combine(_hostEnvironment.WebRootPath, "img", photo.PhotoURL);
            if (System.IO.File.Exists(photoPath))
                System.IO.File.Delete(photoPath);

            return RedirectToAction("UpdateProduct", "Product", new { productId = photo.ProductId });
        }

        //[HttpPost("Photo/UpdateMainPhoto/{photoId}/{photoList}")]
        [HttpGet]
        public IActionResult UpdateMainPhoto([FromQuery]List<GetPhotoViewModel> photoList)
        {
            List<GetPhotoViewModel> updatePhoto = new List<GetPhotoViewModel>();
            int productId = 0;

            //foreach(var photo in photoList)
            //{
            //    if(photo.IsMain == true)
            //    {
            //        photo.IsMain = false;
            //        updatePhoto.Add(photo);
            //        productId = photo.ProductId;
            //        continue;
            //    }
            //    if (photo.Id == photoId)
            //    {
            //        photo.IsMain = true;
            //        updatePhoto.Add(photo);
            //    }
            //}

            var updatePhotoDTO = _mapper.Map<List<UpdatePhotoDTO>>(updatePhoto);

            foreach(var photo in updatePhotoDTO)
            {
                _photoService.Update(photo);
            }

            return RedirectToAction("UpdateProduct", "Product", new { productId = productId });
        }
    }
}
