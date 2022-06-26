using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Admin.ViewModels.ProductViewModels;

namespace OnlineShop.Web.Admin.Components
{
    public class ProductListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<GetProductViewModel> getProductViewModels)
        {
            return View(getProductViewModels);
        }
    }
}
