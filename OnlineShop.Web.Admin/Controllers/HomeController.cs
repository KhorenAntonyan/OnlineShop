using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Web.Admin.ViewModels;
using System.Security.Claims;

namespace OnlineShop.Web.Admin.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            var userId = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


    }
}
