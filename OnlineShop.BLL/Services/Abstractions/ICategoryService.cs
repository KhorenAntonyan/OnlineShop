using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task Add(AddCategoryDTO addCategoryDTO);
        Task<IEnumerable<GetCategoryDTO>> GetAll();
        Task<GetCategoryDTO> FindById(int categoryId);
        Task Update(UpdateCategoryDTO updateCategoryDTO);
        Task Delete(int categoryId);
        Task<List<GetCategoryDTO>> CategorySorting(string sortingBy);
    }
}
