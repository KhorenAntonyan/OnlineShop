using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Web.Admin.ViewModels.PhotoViewModels;

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

        public async Task<IActionResult> DeletePhoto(string photoName)
        {
            var photo = await _photoService.Find(photoName);
            await _photoService.Delete(photo.Id);

            //var photoPath = Path.Combine(_hostEnvironment.WebRootPath, "img", photo.PhotoURL);
            //if (System.IO.File.Exists(photoPath))
            //    System.IO.File.Delete(photoPath);

            return RedirectToAction("UpdateProduct", "Product", new { productId = photo.ProductId });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMainPhoto(UpdateMainPhotoViewModel updateMainPhoto)
        {
            var productId = await _photoService.UpdateMainPhoto(_mapper.Map<UpdateMainPhotoDTO>(updateMainPhoto));

            return RedirectToAction("UpdateProduct", "Product", productId);
        }
    }
}
