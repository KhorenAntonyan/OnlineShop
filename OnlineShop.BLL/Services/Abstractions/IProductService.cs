using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IProductService : IBaseService<Product>
    {
        Task Add(AddProductDTO addProductDTO);
        Task<IEnumerable<GetProductDTO>> GetAll();
        Task<GetProductDTO> FindById(int productId);
        Task Update(UpdateProductDTO updateProductDTO);
        Task Delete(int productId);
        Task<List<GetProductDTO>> ProductSorting(string sortingBy);
        Task<List<GetProductDTO>> GetProductsByFilter(ProductFilterDTO productFilters);
    }
}
