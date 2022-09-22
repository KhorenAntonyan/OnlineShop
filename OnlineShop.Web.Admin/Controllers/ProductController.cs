using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
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
            ProductViewModel productList = new ProductViewModel() { ProductList = products };
            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), "Id", "CategoryName");

            //return View(new ProductViewModel() { ProductList = new List<GetProductViewModel>(), ProductFilter = new ProductFilterViewModel()});
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), "Id", "CategoryName");

            return PartialView("_AddProduct");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel addProduct)
        {
            if (ModelState.IsValid)
            {
                if (addProduct.PhotoFiles == null)
                    addProduct.PhotoFiles = new List<IFormFile>();

                addProduct.PhotoFiles.Add(addProduct.MainPhoto);
                var newProduct = _mapper.Map<AddProductDTO>(addProduct);

               await _productService.Add(newProduct);

                //return RedirectToAction("GetProducts");
            }

            return PartialView("_AddProduct", addProduct);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int productId)
        {
            var updateProduct = _mapper.Map<UpdateProductViewModel>(await _productService.FindById(productId));
            updateProduct.Categories = new SelectList(await _categoryService.GetAll(), "Id", "CategoryName", selectedValue: new { Id = updateProduct.CategoryId });

            return View(updateProduct);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProduct)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<UpdateProductDTO>(updateProduct);

                if (updateProduct.Files != null)
                {
                    var newPhotos = await _photoService.AddFiles(updateProduct.Files, updateProduct.Id);

                    //foreach (var photo in newPhotos)
                    //{
                    //    product.Photos.Add(photo);
                    //}
                }

                await _productService.Update(product);

                return RedirectToAction("GetProducts");
            }

            return await UpdateProduct(updateProduct.Id);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductViewModel deleteProductViewModel)
        {
            var removeProduct = await _productService.FindById(deleteProductViewModel.Id);


            //TODO Move to PhotoService
            foreach (var photo in removeProduct.Photos)
            {
                await _photoService.Delete(photo.ProductId);
                //var photoPath = Path.Combine(_hostEnvironment.WebRootPath, "img", photo.PhotoURL);
                //if (System.IO.File.Exists(photoPath))
                //    System.IO.File.Delete(photoPath);
            }

            await _productService.Delete(deleteProductViewModel.Id);

            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public async Task<IActionResult> ProductSorting(string sortingBy)
        {
            var products = _mapper.Map<List<GetProductViewModel>>(await _productService.ProductSorting(sortingBy));

            return ViewComponent("ProductList", products);
        }

        [HttpPost]
        public async Task<IActionResult> ProductFilter([FromBody]ProductFilterViewModel productFilters)
        {
            var filters = _mapper.Map<ProductFilterDTO>(productFilters);
            //var products = _mapper.Map<List<GetProductViewModel>>(await _productService.ProductFilter(filters));

            var products = await _productService.GetProductsByFilter(filters);
            var pro = _mapper.Map<List<GetProductViewModel>>(products);

            return ViewComponent("ProductList", pro);
        }
    }
}
