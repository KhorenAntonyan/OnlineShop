using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Core.Enums;
using OnlineShop.Web.Admin.ViewModels.ProductViewModels;

namespace OnlineShop.Web.Admin.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetProducts()
        {
            var products = _mapper.Map<List<GetProductViewModel>>(await _productService.GetAll());

            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "Id", "CategoryName");

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(AddProductViewModel addProduct)
        {
            if (ModelState.IsValid)
            {
                if (addProduct.PhotoFiles == null)
                    addProduct.PhotoFiles = new List<IFormFile>();
                addProduct.PhotoFiles.Add(addProduct.MainPhoto);
                var newProduct = _mapper.Map<AddProductDTO>(addProduct);

                _productService.Add(newProduct);

                TempData["message"] = $"{addProduct.ProductName} has been saved";
                return RedirectToAction("GetProducts");
            }

            return View(addProduct);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int productId)
        {
            var updateProduct = _mapper.Map<UpdateProductViewModel>(_productService.FindById(productId));
            updateProduct.Categories = new SelectList(_categoryService.GetAll(), "Id", "CategoryName", selectedValue: new { Id = updateProduct.CategoryId });

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

                return RedirectToAction("GetProducts");
            }

            return UpdateProduct(updateProduct.Id);
        }

        [HttpGet]
        public IActionResult DeleteProduct()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult DeleteProduct(DeleteProductViewModel deleteProductViewModel)
        {
            var removeProduct = _productService.FindById(deleteProductViewModel.Id);

            foreach (var photo in removeProduct.Photos)
            {
                var photoPath = Path.Combine(_hostEnvironment.WebRootPath, "img", photo.PhotoURL);
                if (System.IO.File.Exists(photoPath))
                    System.IO.File.Delete(photoPath);
            }

            _productService.Delete(deleteProductViewModel.Id);

            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public async Task<IActionResult> ProductSorting(string sortingBy)
        {
            var products = _mapper.Map<List<GetProductViewModel>>(await _productService.ProductSorting(sortingBy));

            return ViewComponent("ProductList", products);
        }
    }
}
