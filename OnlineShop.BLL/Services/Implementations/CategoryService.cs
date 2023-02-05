using AutoMapper;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Core.Enums;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.BLL.Services.Implementations
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFilterService _filterService;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IFilterService filterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _filterService = filterService;
        }

        public async Task Add(AddCategoryDTO addCategoryDTO)
        {
            var category = _mapper.Map<Category>(addCategoryDTO);
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetCategoryDTO>> GetAll()
        {
            var categories = _mapper.Map<List<GetCategoryDTO>>(await _unitOfWork.CategoryRepository.GetAllAsync());
            return categories;
        }

        public async Task<GetCategoryDTO> FindById(int categoryId)
        {
            var category = _mapper.Map<GetCategoryDTO>(await _unitOfWork.CategoryRepository.FindByIdAsync(categoryId));
            return category;
        }

        public async Task Delete(int categoryId)
        {
            Category category = await _unitOfWork.CategoryRepository.FindByIdAsync(categoryId);
            await _unitOfWork.CategoryRepository.DeleteAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(UpdateCategoryDTO updateCategoryDTO)
        {
            var updateCategory = _mapper.Map<Category>(updateCategoryDTO);
            await _unitOfWork.CategoryRepository.UpdateAsync(updateCategory);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<GetCategoryDTO>> CategorySorting(string sortingBy)
        {
            var categories = _mapper.Map<List<GetCategoryDTO>>(_unitOfWork.CategoryRepository.GetAllAsync());

            switch (sortingBy)
            {
                case "id":
                    if (_filterService.Id.OrderBy == SortingOrder.Asc)
                    {
                        categories = categories.OrderBy(p => p.Id).ToList();
                        _filterService.Id.OrderBy = SortingOrder.Desc;
                    }
                    else
                    {
                        categories = categories.OrderByDescending(p => p.Id).ToList();
                        _filterService.Id.OrderBy = SortingOrder.Asc;
                    }
                    break;
                case "createdDate":
                    if (_filterService.CategoryCreatedDate.OrderBy == SortingOrder.Asc)
                    {
                        categories = categories.OrderBy(p => p.CreatedDate).ToList();
                        _filterService.CategoryCreatedDate.OrderBy = SortingOrder.Desc;
                    }
                    else
                    {
                        categories = categories.OrderByDescending(p => p.CreatedDate).ToList();
                        _filterService.CategoryCreatedDate.OrderBy = SortingOrder.Asc;
                    }
                    break;
                case "reset":
                    _filterService.Id.OrderBy = SortingOrder.Asc;
                    _filterService.CategoryCreatedDate.OrderBy = SortingOrder.Asc;
                    break;
            }

            return categories;
        }
    }
}
