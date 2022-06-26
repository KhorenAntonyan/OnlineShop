using OnlineShop.Core.Enums;

namespace OnlineShop.BLL.DTOs.CategoryDTOs
{
    public class CategoryFilterDTO
    {
        public CategoryFilterDTO(CategorySortingFilters sortBy, SortingOrder orderBy)
        {
            SortBy = sortBy;
            OrderBy = orderBy;
        }
        public CategorySortingFilters SortBy { get; set; }
        public SortingOrder OrderBy { get; set; }
    }
}
