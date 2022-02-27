using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Web.Admin.ViewModels;

namespace OnlineShop.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel model)
        {
            var _model = new LoginViewModel
            {
                Email = model.Email,
                Password = model.Password
            };

            var jsonData = JsonConvert.SerializeObject(model);

            return View();
        }
    }
}
