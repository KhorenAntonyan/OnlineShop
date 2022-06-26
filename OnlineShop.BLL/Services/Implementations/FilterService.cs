using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Core.Enums;

namespace OnlineShop.BLL.Services.Implementations
{
    public class FilterService : IFilterService
    {
        public ProductFilterDTO Price { get; set; } = new ProductFilterDTO(ProductSortingFilters.Price, SortingOrder.Asc);
        public ProductFilterDTO Quantity { get; set; } = new ProductFilterDTO(ProductSortingFilters.Quantity, SortingOrder.Asc);
        public ProductFilterDTO CreatedDate { get; set; } = new ProductFilterDTO(ProductSortingFilters.CreatedDate, SortingOrder.Asc);
        public CategoryFilterDTO Id { get; set; } = new CategoryFilterDTO(CategorySortingFilters.Id, SortingOrder.Asc);
        public CategoryFilterDTO CategoryCreatedDate { get; set; } = new CategoryFilterDTO(CategorySortingFilters.CategoryCreatedDate, SortingOrder.Asc);
    }
}
