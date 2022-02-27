using OnlineShop.Web.Admin.ViewModels;

namespace OnlineShop.Web.Admin.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
    }
}
