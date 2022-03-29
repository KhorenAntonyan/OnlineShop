using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task Add(CategoryDTO addCategoryDTO);
        IEnumerable<GetCategoryDTO> GetAll();
        public GetCategoryDTO FindById(int categoryId);
        void Update(GetCategoryDTO updateCategoryDTO);
        void Remove(int id);
    }
}
