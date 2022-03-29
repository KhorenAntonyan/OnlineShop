using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Web.Admin.ViewModels;

namespace OnlineShop.Web.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Category()
        {
            var categoryViewModel = _mapper.Map<List<CategoryViewModel>>(_categoryService.GetAll());

            return View(categoryViewModel);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel addCategory)
        {
            var newCategory = _mapper.Map<CategoryDTO>(addCategory);
            _categoryService.Add(newCategory);

            return RedirectToAction("Category");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int categoryId)
        {
            var updateCategory = _mapper.Map<CategoryViewModel>(_categoryService.FindById(categoryId));
            return View(updateCategory);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryViewModel updateCategory)
        {
            var updateCategoryDTO = _mapper.Map<GetCategoryDTO>(updateCategory);
            _categoryService.Update(updateCategoryDTO);

            return RedirectToAction("Category");
        }

        public void RemoveCategory(int categoryID)
        {
            _categoryService.Remove(categoryID);
        }
    }
}
