using OnlineShop.Core.Enums;

namespace OnlineShop.BLL.DTOs.ProductDTOs
{
    public class ProductSortingDTO
    {
        public ProductSortingDTO(ProductSortingFilters sortBy, SortingOrder orderBy)
        {
            SortBy = sortBy;
            OrderBy = orderBy;
        }
        public ProductSortingFilters SortBy { get; set; }
        public SortingOrder OrderBy { get; set; }
    }
}
