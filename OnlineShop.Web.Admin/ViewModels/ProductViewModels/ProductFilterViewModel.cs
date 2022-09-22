namespace OnlineShop.Web.Admin.ViewModels.ProductViewModels
{
    public class ProductFilterViewModel
    {
        public int? PriceRange { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
    }
}
