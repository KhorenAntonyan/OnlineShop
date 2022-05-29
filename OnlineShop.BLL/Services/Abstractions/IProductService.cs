using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IProductService : IBaseService<Product>
    {
        void Add(AddProductDTO addProductDTO);
        IEnumerable<GetProductDTO> GetAll();
        GetProductDTO FindById(int productId);
        void Update(UpdateProductDTO updateProductDTO);
        void Delete(int productId);
    }
}
