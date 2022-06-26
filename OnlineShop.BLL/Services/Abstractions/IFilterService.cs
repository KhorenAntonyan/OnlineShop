using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IFilterService
    {
        ProductFilterDTO Price { get; set; }
        ProductFilterDTO Quantity { get; set; }
        ProductFilterDTO CreatedDate { get; set; }
        CategoryFilterDTO Id { get; set; }
        CategoryFilterDTO CategoryCreatedDate { get; set; }
    }
}
