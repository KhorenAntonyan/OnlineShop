using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface ICategoryService : IBaseService<Category>
    {
        void Add(AddCategoryDTO addCategoryDTO);
        IEnumerable<GetCategoryDTO> GetAll();
        public GetCategoryDTO FindById(int categoryId);
        void Update(UpdateCategoryDTO updateCategoryDTO);
        void Delete(int categoryId);
        Task<List<GetCategoryDTO>> CategorySorting(string sortingBy);
    }
}
