using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Web.Admin.ViewModels;
using System.Security.Claims;

namespace OnlineShop.Web.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            var userId = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> IndexAsync()
        {
            //var username = HttpContext.Current.User.Identity.Name;

            //var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            //var user = authState.User;

            //if(!User.Identities.FirstOrDefault(u => u.Claims.))
            //{
            //    return RedirectToAction("Login", "Auth");
            //}
            return View();
        }


    }
}
