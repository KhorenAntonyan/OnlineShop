using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Services.Abstractions;

namespace OnlineShop.Web.Admin.Controllers
{
    [Authorize]
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

        public IActionResult DeletePhoto(string photoName)
        {
            var photo = _photoService.Find(photoName);

            _photoService.Delete(photo.Id);

            var photoPath = Path.Combine(_hostEnvironment.WebRootPath, "img", photo.PhotoURL);
            if (System.IO.File.Exists(photoPath))
                System.IO.File.Delete(photoPath);

            return RedirectToAction("UpdateProduct", "Product", new { productId = photo.ProductId });
        }

        [Route("Photo/UpdateMainPhoto/{photoId}/{mainPhotoId}")]
        public IActionResult UpdateMainPhoto(int photoId, int mainPhotoId)
        {
            var productId = _photoService.UpdateMainPhoto(photoId, mainPhotoId);

            return RedirectToAction("UpdateProduct", "Product", new { productId = productId });
        }
    }
}
