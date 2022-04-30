using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Web.Admin.ViewModels.ProductViewModels
{
    public class AddProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose product category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please add product description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter product price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter product quantity")]
        public int Quantity { get; set; }
        public List<IFormFile>? PhotoFiles { get; set; }
        public IFormFile? MainPhoto { get; set; }
    }
}
