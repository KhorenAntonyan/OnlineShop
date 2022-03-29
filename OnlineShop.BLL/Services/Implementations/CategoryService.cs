using AutoMapper;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.BLL.Services.Implementations
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task Add(CategoryDTO addCategoryDTO)
        {
            var category = _mapper.Map<Category>(addCategoryDTO);
            unitOfWork.CategoryRepository.Add(category);
            unitOfWork.Save();
            return Task.CompletedTask;
        }

        public IEnumerable<GetCategoryDTO> GetAll()
        {
            var categories = _mapper.Map<List<GetCategoryDTO>>(unitOfWork.CategoryRepository.GetAll());
            return categories;
        }

        public GetCategoryDTO FindById(int categoryId)
        {
            var updateCategory = _mapper.Map<GetCategoryDTO>(unitOfWork.CategoryRepository.FindById(categoryId));
            return updateCategory;
        }

        public void Remove(int categoryId)
        {
            Category category = unitOfWork.CategoryRepository.FindById(categoryId);
            unitOfWork.CategoryRepository.Remove(category);
            unitOfWork.Save();
        }

        public void Update(GetCategoryDTO updateCategoryDTO)
        {
            //Category updateCategory = unitOfWork.CategoryRepository.FindById(updateCategoryDTO.Id);
            var updateCategory = _mapper.Map<Category>(updateCategoryDTO);
            unitOfWork.CategoryRepository.Update(updateCategory);
            unitOfWork.Save();
        }
    }
}
