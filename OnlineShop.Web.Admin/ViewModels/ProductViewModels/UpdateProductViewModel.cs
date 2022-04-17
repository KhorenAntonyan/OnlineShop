using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop.Web.Admin.ViewModels.ProductViewModels
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<string> Photos { get; set; }
    }
}
