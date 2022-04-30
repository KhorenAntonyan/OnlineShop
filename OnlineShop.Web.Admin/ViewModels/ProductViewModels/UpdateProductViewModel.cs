using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Web.Admin.ViewModels.PhotoViewModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Web.Admin.ViewModels.ProductViewModels
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose product category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please add product description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter product price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter product quantity")]
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<IFormFile>? Files { get; set; }
        public List<GetPhotoViewModel> Photos { get; set; }
        public bool IsMainPhoto { get; set; }
    }
}
