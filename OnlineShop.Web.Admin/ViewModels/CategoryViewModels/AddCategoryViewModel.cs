using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Web.Admin.ViewModels.CategoryViewModels
{
    public class AddCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Please add category description")]
        public string Description { get; set; }
    }
}
