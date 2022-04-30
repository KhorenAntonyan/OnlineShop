using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Web.Admin.ViewModels.ProductViewModels;

namespace OnlineShop.Web.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductService productService, ICategoryService categoryService, IPhotoService photoService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _photoService = photoService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Product()
        {
            var products = _mapper.Map<List<GetProductViewModel>>(_productService.GetAll());

            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel addProduct)
        {
            if (ModelState.IsValid)
            {
                addProduct.PhotoFiles.Add(addProduct.MainPhoto);

                var newProduct = _mapper.Map<AddProductDTO>(addProduct);

                //List<string> photoList = new List<string>();
                //if (addProduct.PhotoFiles != null)
                //{
                //    var addPhotos = _photoService.AddFiles(addProduct.PhotoFiles, addProduct.Id);

                //    foreach (string photo in addPhotos)
                //    {
                //        photoList.Add(photo);
                //    }
                //    newProduct.Photos = photoList;
                //}

                _productService.Add(newProduct);

                TempData["message"] = $"{addProduct.ProductName} has been saved";
                return RedirectToAction("Product");
            }

            return View(addProduct);

        }

        [HttpGet]
        public IActionResult UpdateProduct(int productId)
        {
            var updateProduct = _mapper.Map<UpdateProductViewModel>(_productService.FindById(productId));
            updateProduct.Categories = new SelectList(_categoryService.GetAll(), "Id", "CategoryName", selectedValue: new {Id = updateProduct.CategoryId});

            return View(updateProduct);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel updateProduct)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<UpdateProductDTO>(updateProduct);

                if (updateProduct.Files != null)
                {
                    var newPhotos = _photoService.AddFiles(updateProduct.Files, updateProduct.Id);

                    //foreach (var photo in newPhotos)
                    //{
                    //    product.Photos.Add(photo);
                    //}
                }

                _productService.Update(product);

                return RedirectToAction("Product");
            }


            return UpdateProduct(updateProduct.Id);
        }

        public IActionResult RemoveProduct(int productId)
        {
            var removeProduct = _productService.FindById(productId);

            foreach(var photo in removeProduct.Photos)
            {
                var photoPath = Path.Combine(_hostEnvironment.WebRootPath, "img", photo.PhotoURL);
                if (System.IO.File.Exists(photoPath))
                    System.IO.File.Delete(photoPath);
            }

            _productService.Remove(productId);

            return RedirectToAction("Product");
        }
    }
}
