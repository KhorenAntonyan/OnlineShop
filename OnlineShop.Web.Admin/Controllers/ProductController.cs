using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Web.Admin.ViewModels;

namespace OnlineShop.Web.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Product()
        {
            var products = _mapper.Map<List<ProductViewModel>>(_productService.GetAll());

            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel addProduct)
        {
            var newProduct = _mapper.Map<AddProductDTO>(addProduct);

            _productService.Add(newProduct);
            return RedirectToAction("Product");
        }

        [HttpGet]
        public IActionResult UpdateProduct()
        {
            //ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProduct(int productId)
        {
            _productService.Update(productId);

            return RedirectToAction("Product");
        }

        public void RemoveProduct(int productId)
        {
            _productService.Remove(productId);
        }
    }
}
