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

        public void Add(AddCategoryDTO addCategoryDTO)
        {
            var category = _mapper.Map<Category>(addCategoryDTO);
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Save();
        }

        public IEnumerable<GetCategoryDTO> GetAll()
        {
            var categories = _mapper.Map<List<GetCategoryDTO>>(_unitOfWork.CategoryRepository.GetAll());
            return categories;
        }

        public GetCategoryDTO FindById(int categoryId)
        {
            var category = _mapper.Map<GetCategoryDTO>(_unitOfWork.CategoryRepository.FindById(categoryId));
            return category;
        }

        public void Delete(int categoryId)
        {
            Category category = _unitOfWork.CategoryRepository.FindById(categoryId);
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Save();
        }

        public void Update(UpdateCategoryDTO updateCategoryDTO)
        {
            var updateCategory = _mapper.Map<Category>(updateCategoryDTO);
            _unitOfWork.CategoryRepository.Update(updateCategory);
            _unitOfWork.Save();
        }

        public async Task<List<GetCategoryDTO>> CategorySorting(string sortingBy)
        {
            var categories = _mapper.Map<List<GetCategoryDTO>>(_unitOfWork.CategoryRepository.GetAll());

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
