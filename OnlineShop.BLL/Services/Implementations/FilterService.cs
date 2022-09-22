using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Core.Enums;

namespace OnlineShop.BLL.Services.Implementations
{
    public class FilterService : IFilterService
    {
        public ProductSortingDTO Price { get; set; } = new ProductSortingDTO(ProductSortingFilters.Price, SortingOrder.Asc);
        public ProductSortingDTO Quantity { get; set; } = new ProductSortingDTO(ProductSortingFilters.Quantity, SortingOrder.Asc);
        public ProductSortingDTO CreatedDate { get; set; } = new ProductSortingDTO(ProductSortingFilters.CreatedDate, SortingOrder.Asc);
        public CategoryFilterDTO Id { get; set; } = new CategoryFilterDTO(CategorySortingFilters.Id, SortingOrder.Asc);
        public CategoryFilterDTO CategoryCreatedDate { get; set; } = new CategoryFilterDTO(CategorySortingFilters.CategoryCreatedDate, SortingOrder.Asc);
    }
}
