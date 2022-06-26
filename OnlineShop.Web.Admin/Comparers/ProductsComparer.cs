using OnlineShop.Core.Enums;
using OnlineShop.Web.Admin.ViewModels.ProductViewModels;

namespace OnlineShop.Web.Admin.Comparers
{
    public class ProductsComparer  // IComparer<ProductListViewModel>
    {
        public ProductSortingFilters SortBy { get; set; }

        //public int Compare(ProductListViewModel x, ProductListViewModel y)
        //{
        //    //if (SortBy == ProductSortingFilters.PriceAscending || SortBy == ProductSortingFilters.QuantityAscending || SortBy == ProductSortingFilters.CreatedDateAscending)
        //    //    if (x.Price > y.Price)
        //    //        return 1;
        //    //    else if (x.Price < y.Price)
        //    //        return -1;
        //    //    else
        //    //        return 0;

        //    //if (SortBy == ProductSortingFilters.PriceAscending)
        //    //    if (x.Price > y.Price)
        //    //        return 1;
        //    //    else if (x.Price < y.Price)
        //    //        return -1;
        //    //    else
        //    //        return 0;
        //    //else
        //    //    if (x.Price < y.Price)
        //    //         return 1;
        //    //    else if (x.Price > y.Price)
        //    //         return -1;
        //    //    else
        //    //         return 0;

        //}
    }
}
