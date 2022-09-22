using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Web.Admin.ViewModels.CategoryViewModels;

namespace OnlineShop.Web.Admin.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetCategories()
        {
            var categories = _mapper.Map<List<GetCategoryViewModel>>(await _categoryService.GetAll());

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return PartialView("_AddCategory");
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel addCategory)
        {
            if (ModelState.IsValid)
            {
                var newCategory = _mapper.Map<AddCategoryDTO>(addCategory);
                await _categoryService.Add(newCategory);

                return RedirectToAction("GetCategories");
            }

            return PartialView("_AddCategory", addCategory);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int categoryId)
        {
            var updateCategory = _mapper.Map<UpdateCategoryViewModel>(await _categoryService.FindById(categoryId));

            return View(updateCategory);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel updateCategory)
        {
            if (ModelState.IsValid)
            {
                var updateCategoryDTO = _mapper.Map<UpdateCategoryDTO>(updateCategory);
                await _categoryService.Update(updateCategoryDTO);

                return RedirectToAction("GetCategories");
            }

            return await UpdateCategory(updateCategory.Id);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            await _categoryService.Delete(deleteCategoryViewModel.Id);

            return RedirectToAction("GetCategories");
        }

        [HttpGet]
        public async Task<IActionResult> CategorySorting(string sortingBy)
        {
            var categories = _mapper.Map<List<GetCategoryViewModel>>(await _categoryService.CategorySorting(sortingBy));

            return ViewComponent("CategoryList", categories);
        }
    }
}
