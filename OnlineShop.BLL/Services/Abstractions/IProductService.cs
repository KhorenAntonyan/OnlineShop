using OnlineShop.BLL.DTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IProductService : IBaseService<Product>
    {
        Task Add(AddProductDTO addProductDTO);
    }
}
