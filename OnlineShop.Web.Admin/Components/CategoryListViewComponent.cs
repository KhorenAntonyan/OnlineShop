using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Admin.ViewModels.CategoryViewModels;

namespace OnlineShop.Web.Admin.Components
{
    public class CategoryListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<GetCategoryViewModel> getCategoryViewModels)
        {
            return View(getCategoryViewModels);
        }
    }
}
