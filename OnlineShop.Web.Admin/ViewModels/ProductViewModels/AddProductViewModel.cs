namespace OnlineShop.Web.Admin.ViewModels.ProductViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
