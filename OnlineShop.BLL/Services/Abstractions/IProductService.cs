using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IProductService : IBaseService<Product>
    {
        Task Add(AddProductDTO addProductDTO);
        IEnumerable<AddProductDTO> GetAll();
        void Update(int productId);
        void Remove(int id);
    }
}
