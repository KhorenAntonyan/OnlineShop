﻿using AutoMapper;
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
        public IActionResult GetCategories()
        {
            var categoryViewModel = _mapper.Map<List<GetCategoryViewModel>>(_categoryService.GetAll());

            return View(categoryViewModel);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel addCategory)
        {
            if (ModelState.IsValid)
            {
                var newCategory = _mapper.Map<AddCategoryDTO>(addCategory);
                _categoryService.Add(newCategory);

                return RedirectToAction("GetCategories");
            }

            return View(addCategory);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int categoryId)
        {
            var updateCategory = _mapper.Map<UpdateCategoryViewModel>(_categoryService.FindById(categoryId));

            return View(updateCategory);
        }

        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryViewModel updateCategory)
        {
            if (ModelState.IsValid)
            {
                var updateCategoryDTO = _mapper.Map<UpdateCategoryDTO>(updateCategory);
                _categoryService.Update(updateCategoryDTO);

                return RedirectToAction("GetCategories");
            }

            return UpdateCategory(updateCategory.Id);
        }

        [HttpGet]
        public IActionResult DeleteCategory()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            _categoryService.Delete(deleteCategoryViewModel.Id);

            return RedirectToAction("GetCategories");
        }
    }
}
