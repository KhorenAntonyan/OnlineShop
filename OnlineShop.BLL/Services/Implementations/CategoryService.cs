using AutoMapper;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.BLL.Services.Implementations
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
    }
}
