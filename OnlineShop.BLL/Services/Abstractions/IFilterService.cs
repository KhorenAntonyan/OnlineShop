using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;

namespace OnlineShop.BLL.Services.Abstractions
{
    public interface IFilterService
    {
        ProductSortingDTO Price { get; set; }
        ProductSortingDTO Quantity { get; set; }
        ProductSortingDTO CreatedDate { get; set; }
        CategoryFilterDTO Id { get; set; }
        CategoryFilterDTO CategoryCreatedDate { get; set; }
    }
}
