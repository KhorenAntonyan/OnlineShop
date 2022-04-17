using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Web.Admin.ViewModels;

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
            if(System.IO.File.Exists(photoPath))
                System.IO.File.Delete(photoPath);

            return RedirectToAction("UpdateProduct", "Product", new {productId = photo.ProductId});
        }
    }
}
