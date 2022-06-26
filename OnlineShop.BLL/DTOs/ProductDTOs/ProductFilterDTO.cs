using OnlineShop.Core.Enums;

namespace OnlineShop.BLL.DTOs.ProductDTOs
{
    public class ProductFilterDTO
    {
        public ProductFilterDTO(ProductSortingFilters sortBy, SortingOrder orderBy)
        {
            SortBy = sortBy;
            OrderBy = orderBy;
        }
        public ProductSortingFilters SortBy { get; set; }
        public SortingOrder OrderBy { get; set; }
    }
}
