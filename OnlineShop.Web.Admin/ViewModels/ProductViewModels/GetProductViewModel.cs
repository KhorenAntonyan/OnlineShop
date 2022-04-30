using OnlineShop.Web.Admin.ViewModels.PhotoViewModels;

namespace OnlineShop.Web.Admin.ViewModels.ProductViewModels
{
    public class GetProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<GetPhotoViewModel> Photos { get; set; }
    }
}
